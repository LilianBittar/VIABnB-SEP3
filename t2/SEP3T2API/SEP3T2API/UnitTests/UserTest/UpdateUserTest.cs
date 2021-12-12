using System;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation.UserValidation;

namespace UnitTests.UserTest
{
    [TestFixture]
    public class UpdateUserTest
    {
        private User _user = new User();
        private IUserService _userService;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void SetUp()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object, new UserValidation());
        }

        [Test]
        public void UpdateUserWithValidArgumentsDoesNotThrowExceptionsTest()
        {
            _user = new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.tt",
                Password = "Aa111111",
                PhoneNumber = "11111111",
                ProfileImageUrl = "Test"
            };
            Assert.DoesNotThrowAsync(() => _userService.UpdateUserAsync(_user));
        }

        [TestCase("email@gmailcom")]
        [TestCase("emailgmailcom")]
        [TestCase("email@gmail.com.")]
        [TestCase(null)]
        public void UpdateUserWithInvalidEmailThrowsExceptionTest(string email)
        {
            _user = new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = email,
                Password = "Aa11",
                PhoneNumber = "+4511111111",
                ProfileImageUrl = "Test"
            };

            Assert.ThrowsAsync<ArgumentException>(() => _userService.UpdateUserAsync(_user));
        }
        
        [TestCase("Test34")]
        [TestCase("!%/)(")]
        [TestCase(null)]
        public void UpdateUserWithInvalidFirstNameThrowsExceptionTest(string firstName)
        {
            _user = new User()
            {
                Id = 1,
                FirstName = firstName,
                LastName = "Test",
                Email = "Test@test.tt",
                Password = "Aa111111",
                PhoneNumber = "11111111",
                ProfileImageUrl = "Test"
            };
            Assert.ThrowsAsync<ArgumentException>(() => _userService.UpdateUserAsync(_user));
        }
        
        [TestCase("Test34")]
        [TestCase("!%/)(")]
        [TestCase(null)]
        public void UpdateUserWithInvalidLastNameThrowsExceptionTest(string lastName)
        {
            _user = new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = lastName,
                Email = "Test@test.tt",
                Password = "Aa111111",
                PhoneNumber = "11111111",
                ProfileImageUrl = "Test"
            };
            Assert.ThrowsAsync<ArgumentException>(() => _userService.UpdateUserAsync(_user));
        }
        
        [TestCase("Aa1")]
        [TestCase(null)]
        [TestCase("1")]
        [TestCase("121232132131233")]
        [TestCase("hedsafasdfasdfsdaf")]
        [TestCase("AKSHASKHGas")]
        [TestCase("12345")]
        [TestCase("1234567")]
        public void UpdateUserWithInvalidPasswordThrowsExceptionTest(string password)
        {
            _user = new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.tt",
                Password = password,
                PhoneNumber = "11111111",
                ProfileImageUrl = "Test"
            };

            Assert.ThrowsAsync<ArgumentException>(() => _userService.UpdateUserAsync(_user));
        }

        [TestCase("+23423434")]
        [TestCase("345345a")]
        [TestCase(null)]
        public void UpdateUserWithInvalidPhoneNumberThrowsExceptionTest(string phoneNumber)
        {
            _user = new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.tt",
                Password = "Aa111111",
                PhoneNumber = phoneNumber,
                ProfileImageUrl = "Test"
            };
            Assert.ThrowsAsync<ArgumentException>(() => _userService.UpdateUserAsync(_user));
        }
    }
}