using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public class MessagingService : IMessagingService
    {
        /// <summary>
        /// HashMap that contains all messages. The key is a userId and value is an Queue
        /// containing all messages for the user;
        /// </summary>
        private readonly Dictionary<int, Queue<Message>> _messageMap = new();

        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessagingService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            var allMessages = _messageRepository.GetAllMessagesAsync().Result;
            // Initializing the messageMap with a new queue
            // Initializing is a bit slow, since we loop through the messages twice. 
            foreach (var message in allMessages)
            {
                // Adds all users that has ever sent or received an message to the map. 
                if (!_messageMap.ContainsKey(message.Receiver.Id))
                {
                    _messageMap.TryAdd(message.Receiver.Id, new Queue<Message>()); 
                }

                if (!_messageMap.ContainsKey(message.Sender.Id))
                {
                    _messageMap.TryAdd(message.Sender.Id, new Queue<Message>()); 
                }
            }
        }

        public async Task<Message> SendMessageAsync(Message message)
        {
            if (message == null)
            {
                throw new ArgumentException("Message cannot be null");
            }

            var existingUser = await _userRepository.GetUserByIdAsync(message.Receiver.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("Receiver does not exist");
            }

            try
            {
                var newMessage = await _messageRepository.CreateMessageAsync(message);
                
                return newMessage;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}