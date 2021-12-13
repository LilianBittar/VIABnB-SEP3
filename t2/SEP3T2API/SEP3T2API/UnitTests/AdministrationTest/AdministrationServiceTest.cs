using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories.Administration;
using SEP3T2GraphQL.Services.Administration;
using SEP3T2GraphQL.Services.Administration.Impl;

namespace UnitTests.AdministrationTest
{
    [TestFixture]
    public class AdministrationServiceTest
    {
        private Administrator _administrator;
        private IAdministrationService _administrationService;
        private Mock<IAdministrationRepository> _administrationRepository;

        [SetUp]
        public void SetUp()
        {
            _administrator = new Administrator()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.tt",
                Password = "Aa11",
                PhoneNumber = "11111111"
            };
            _administrationRepository = new Mock<IAdministrationRepository>();
            _administrationService = new AdministrationService(_administrationRepository.Object);
        }

        [Test]
        public void GetAdminByEmailDoesNotThrowExceptionsTest()
        {
            var adminList = new List<Administrator>() {_administrator};
            var email = "Test@test.tt";
            _administrationRepository.Setup<IEnumerable<Administrator>>(x => x.GetAllAdmins().Result)
                .Returns(adminList);
            Assert.DoesNotThrowAsync(async () => await _administrationService.GetAdminByEmail(email));
        }

        [TestCase(null)]
        [TestCase("")]
        public void GetAdminByInvalidEmailThrowsArgumentExceptionTest(string email)
        {
            var adminList = new List<Administrator>() {_administrator};
            _administrationRepository.Setup<IEnumerable<Administrator>>(x => x.GetAllAdmins().Result)
                .Returns(adminList);
            Assert.ThrowsAsync<ArgumentException>(async () => await _administrationService.GetAdminByEmail(email));
        }
    }
}