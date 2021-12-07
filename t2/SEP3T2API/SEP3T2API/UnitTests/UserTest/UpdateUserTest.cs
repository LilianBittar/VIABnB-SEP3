using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;

namespace UnitTests.UserTest
{
    [TestFixture]
    public class UpdateUserTest
    {
        private User _user;
        private IUserService _userService;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void SetUp()
        {
            _user = new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.tt",
                Password = "Aa11",
                PhoneNumber = "+4511111111",
                ProfileImageUrl = "Test"
            };
        }
    }
}