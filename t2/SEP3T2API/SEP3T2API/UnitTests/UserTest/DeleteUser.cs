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
    public class DeleteUser
    {
        private User _user = new User();
        private IUserService _userService;
        private Mock<IUserRepository> _userRepository;
        
        [SetUp]
        public void SetUp()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object, new UserValidation(_userRepository.Object));
        }

        [Test]
        public void DeleteUserDoesNotThrowExceptionTest()
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
            
            Assert.DoesNotThrowAsync(()=> _userService.DeleteUserSync(_user));
        }

        [TestCase(-100)]
        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        public void DeleteUserWithInvalidIdThrowsExceptionTest(int id)
        {
            _user = new User()
            {
                Id = id,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.tt",
                Password = "Aa111111",
                PhoneNumber = "11111111",
                ProfileImageUrl = "Test"
            };
            
            Assert.ThrowsAsync<ArgumentException>(()=> _userService.DeleteUserSync(_user));
        }
    }
}