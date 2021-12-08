using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services;

namespace SEP3T2GraphQL.SignalR
{
    public class MessagingHub : Hub
    {
        private readonly IMessagingService _messagingService;
        private readonly IUserService _userService;

        /// Maps the connected users' userId to a connection string to be used for direct messaging.  
        private static ConcurrentDictionary<int, string> _clients = new();

        public MessagingHub(IMessagingService messagingService, IUserService userService)
        {
            _messagingService = messagingService;
            _userService = userService;
        }

        public override async Task OnConnectedAsync()
        {
            var userEmail = Context.GetHttpContext().Request.Query["email"];
            var existingUser = await _userService.GetUserByEmailAsync(userEmail);
            if (existingUser != null)
            {
                Join(existingUser.Id);
                Console.WriteLine($"User with email {existingUser.Email} joined.");
            }
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            foreach (var key in _clients.Keys)
            {
                if (_clients[key] == Context.ConnectionId)
                {
                    Disconnect(key);
                }
            }
        }

        public async Task SendMessageAsync(string messageAsJson)
        {
            var message = JsonSerializer.Deserialize<Message>(messageAsJson);
            try
            {
                var sentMessage = await _messagingService.SendMessageAsync(message);
                var sentMessageAsJson = JsonSerializer.Serialize(sentMessage,
                    new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                await Clients.Client(_clients[sentMessage.Receiver.Id])
                    .SendCoreAsync("ReceiveMessage", new object[] {sentMessageAsJson});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void Join(int userId)
        {
            _clients.TryAdd(userId, Context.ConnectionId);
        }

        public void Disconnect(int userId)
        {
            if (_clients.ContainsKey(userId))
            {
                var connectionString = _clients[userId];
                _clients.TryRemove(userId, out _);
            }
        }
    }
}