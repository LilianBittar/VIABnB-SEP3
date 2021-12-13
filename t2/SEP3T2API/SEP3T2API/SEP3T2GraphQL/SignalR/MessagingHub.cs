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
                // Each time a client joins, they get a new connection string
                // If user has already been connected before without disconnecting, then we update the string. 
                if (_clients.ContainsKey(existingUser.Id))
                {
                    Console.WriteLine(
                        $"{this} updating user {existingUser.Id} with new connection string {Context.ConnectionId}");
                    _clients[existingUser.Id] = Context.ConnectionId;
                }

                Join(existingUser.Id);
                Console.WriteLine(
                    $"User with email {existingUser.Email} joined with connection {Context.ConnectionId}.");
            }
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            // This method is a bit slow, since we might have to loop through every key in the map.
            // Might have to switch the key / value such that connectionId is the key instead, but 
            // switching the key would result in slower sending of messages, since that method
            // uses the quick lookup time of dictionary/map. 
            foreach (var key in _clients.Keys)
            {
                if (_clients[key] == Context.ConnectionId)
                {
                    Disconnect(key);
                    break;
                }
            }
        }

        public async Task GetMessages()
        {
            // This method is a bit slow, since we might have to loop through every key in the map.
            // Might have to switch the key / value such that connectionId is the key instead, but 
            // switching the key would result in slower sending of messages, since that method
            // uses the quick lookup time of dictionary/map. 
            foreach (var key in _clients.Keys)
            {
                if (_clients[key] == Context.ConnectionId)
                {
                    Console.WriteLine($"{this} received request for {nameof(GetMessages)} from {Context.ConnectionId}");
                    var messages = await _messagingService.GetMessagesByUserIdAsync(key);
                    var messagesAsJson = JsonSerializer.Serialize(messages,
                        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    await Clients.Client(_clients[key])
                        .SendCoreAsync("ReceiveUserMessages", new object[] { messagesAsJson });
                    break;
                }
            }
        }
        /// <summary>
        /// Sends a message directly to user, if user is connected to the chat. 
        /// </summary>
        /// <remarks>
        /// Sender client and Receiver client must be listening to the "ReceiveMessage" event
        /// from the server for real time messaging to work properly. 
        /// All messages are sent as strings in JSON Format. 
        /// </remarks> 
        /// <param name="messageAsJson">The message in JSON format.</param>
        /// <returns></returns>
        public async Task SendMessage(string messageAsJson)
        {
            Console.WriteLine($"{this} received request for {nameof(SendMessage)} with param {messageAsJson}");
            var message = JsonSerializer.Deserialize<Message>(messageAsJson,
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            try
            {
                var sentMessage = await _messagingService.SendMessageAsync(message);
                var sentMessageAsJson = JsonSerializer.Serialize(sentMessage,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                if (_clients.ContainsKey(sentMessage.Receiver.Id))
                {
                    // Message is only sent as direct message if receiver of message is 
                    // connected to server. Else the message is just stored and the receiver
                    // will receive the messages the next time the receiver joins. 
                    await Clients.Client(_clients[sentMessage.Receiver.Id])
                        .SendCoreAsync("ReceiveMessage", new object[] { sentMessageAsJson });
                }

                // This check is probably unnessecary since the Sender needs to be connected
                // Before the SendMessage method can be invoked, but is here just in case
                // Sender disconnected during the invokation of this method
                if (_clients.ContainsKey(sentMessage.Sender.Id))
                {
                    await Clients.Client(_clients[sentMessage.Sender.Id])
                        .SendCoreAsync("ReceiveMessage", new object[] { sentMessageAsJson });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Adds the user represented by userId and an connection string to the map of connectec clients.
        /// </summary>
        /// <remarks>
        /// The user will receive all messages that the user have sent or received upon joining.
        /// The client must listen to the event ReceiveUserMessages from the server to receive the messages
        /// </remarks>
        /// <param name="userId">the userId of the user that connected to the chat</param>
        private async void Join(int userId)
        {
            _clients.TryAdd(userId, Context.ConnectionId);
            await Clients.Client(_clients[userId])
                .SendCoreAsync("ReceiveUserMessages",
                    new object[] { await _messagingService.GetMessagesByUserIdAsync(userId) });
        }
        /// <summary>
        /// Removes the user from the map of connected clients. 
        /// </summary>
        /// <param name="userId">the userId of the user that disconnected</param>
        public void Disconnect(int userId)
        {
            if (_clients.ContainsKey(userId))
            {
                Console.WriteLine($"User with id {userId} disconnected");
                var connectionString = _clients[userId];
                _clients.TryRemove(userId, out _);
            }
        }
    }
}