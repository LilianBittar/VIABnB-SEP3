using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation.HostValidation;

namespace UnitTests.AdministrationTest
{
    [TestFixture]
    public class ReadAndUpdateHostRequestTest
    {
        private IHostService _hostService;
        private IEnumerable<Host> _hostList;
        [SetUp]
        public void SetUp()
        {
            var host1 = new Host()
            {
                Id = 1,
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                PhoneNumber = "12345678",
                Email = "Test@Email.tt",
                Password = "PasswordTest1234",
                HostReviews = new List<HostReview>(),
                ProfileImageUrl = "ImageTest",
                Cpr = "1234567891",
                IsApprovedHost = false
            };
            
            var host2 = new Host()
            {
                Id = 2,
                FirstName = "FirstNameTestTest",
                LastName = "LastNameTestTest",
                PhoneNumber = "87654321",
                Email = "TestTest@Email.tt",
                Password = "PasswordTestTest1234",
                HostReviews = new List<HostReview>(),
                ProfileImageUrl = "ImageTestTest",
                Cpr = "1987654321",
                IsApprovedHost = false
            };
            _hostList = new List<Host> {host1, host2};
            
            var hostRepository = new Mock<IHostRepository>();
            hostRepository.Setup(ex => ex.GetAllNotApprovedHostsAsync().Result).Returns(_hostList);
            hostRepository.Setup(ex => ex.UpdateHostStatusAsync(host1).Result).Returns(host1);

            var userService = new Mock<IUserService>();
            _hostService = new HostService(hostRepository.Object, new HostValidation(userService.Object));
        }

        [Test]
        public void GetNotNullListOfAllNotApprovedHostDoesNotThrowExceptionTest()
        {
            Assert.DoesNotThrowAsync(()=> _hostService.GetAllNotApprovedHostsAsync());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdateHostRequestThrowsNoExceptionsTest(bool status)
        {
            var hostToUpdate = _hostList.First(h => h.Id == 1);
            hostToUpdate.IsApprovedHost = status;
            Assert.DoesNotThrowAsync(()=> _hostService.UpdateHostStatusAsync(hostToUpdate));
        }

        [Test]
        public void UpdateANullHostThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _hostService.UpdateHostStatusAsync(null));
        }
    }
}