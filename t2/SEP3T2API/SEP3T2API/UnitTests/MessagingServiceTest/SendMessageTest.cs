using System;
using HotChocolate.Types;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;

namespace UnitTests.MessagingServiceTest
{
    [TestFixture]
    public class SendMessageTest
    {
        private Mock<IMessageRepository> _messageRepository;
        private Mock<IUserRepository> _userRepository; 
        private IMessagingService _messagingService;
        private User _sender;

        [SetUp]
        public void SetUp()
        {
            _messageRepository = new Mock<IMessageRepository>();
            _userRepository = new Mock<IUserRepository>();
            _messagingService = new MessagingService(_messageRepository.Object, _userRepository.Object);
            _sender = new User()
            {
                Email = "293886@via.dk", FirstName = "Michael", Id = 2, Password = "Test1234", LastName = "Bui",
                PhoneNumber = "88888888", ProfileImageUrl = "Test"
            }; 
        }


        [Test]
        public void SendMessage_MessageIsNull_ThrowsArgumentException()
        {
            Message message = null;
        }



        private void TestSendMessageThrowsAsyncT<T>(Message message) where T: SystemException
        {
            Assert.ThrowsAsync<T>(async () => await _messagingService.SendMessageAsync(message)); 
        } 
    }
}