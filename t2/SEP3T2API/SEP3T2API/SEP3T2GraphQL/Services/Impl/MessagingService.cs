using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ConcurrentDictionary<int, ConcurrentQueue<Message>> _messageMap = new();

        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessagingService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            InitializeMessageMap();
        }

        public async Task<Message> SendMessageAsync(Message message)
        {
            if (message == null)
            {
                throw new ArgumentException("Message cannot be null");
            }

            try
            {
                var existingUser = await _userRepository.GetUserByIdAsync(message.Receiver.Id);
                if (existingUser == null)
                {
                    throw new KeyNotFoundException("Receiver does not exist");
                }
            }
            catch (NullReferenceException e)
            {
                    throw new KeyNotFoundException("Receiver does not exist");
            }
            try
            {
                message.TimeSent = DateTime.UtcNow;
                var newMessage = await _messageRepository.CreateMessageAsync(message);
                // Adding sender / receiver to map with a new message queue in case they have never sent / received a message before. 
                if (!_messageMap.ContainsKey(message.Receiver.Id))
                {
                    _messageMap.TryAdd(message.Receiver.Id, new ConcurrentQueue<Message>());
                }

                if (!_messageMap.ContainsKey(message.Sender.Id))
                {
                    _messageMap.TryAdd(message.Sender.Id, new ConcurrentQueue<Message>());
                }
                _messageMap[message.Receiver.Id].Enqueue(newMessage);
                _messageMap[message.Sender.Id].Enqueue(newMessage);
                return newMessage;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int userId)
        {
            return _messageMap.ContainsKey(userId) ? _messageMap[userId] : new List<Message>().AsEnumerable();
        }

        public void ConnectUser(int userId)
        {
            if (!_messageMap.ContainsKey(userId))
            {
                _messageMap.TryAdd(userId, new ConcurrentQueue<Message>());
            }
        }


        private void InitializeMessageMap()
        {
            var allMessages = _messageRepository.GetAllMessagesAsync().Result;
            // Initializing the messageMap with a new queue
            foreach (var message in allMessages)
            {
                // Adds all users that has ever sent or received an message to the map. 
                if (!_messageMap.ContainsKey(message.Receiver.Id))
                {
                    _messageMap.TryAdd(message.Receiver.Id, new ConcurrentQueue<Message>());
                }

                if (!_messageMap.ContainsKey(message.Sender.Id))
                {
                    _messageMap.TryAdd(message.Sender.Id, new ConcurrentQueue<Message>());
                }
                _messageMap[message.Sender.Id].Enqueue(message);
                _messageMap[message.Receiver.Id].Enqueue(message);
            }
        }
    }
}