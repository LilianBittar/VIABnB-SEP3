using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;
using GuestReview = SEP3T2GraphQL.Models.GuestReview;
using HostReview = SEP3T2GraphQL.Models.HostReview;

namespace UnitTests.AdministrationTest
{
    [TestFixture]
    public class ReadAndUpdateGuestRequestTest
    {
        private IGuestService _guestService;
        private IEnumerable<Guest> _guestList;

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
            
            var guest1 = new Guest()
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
                IsApprovedHost = false,
                ViaId = 123456,
                GuestReviews = new List<GuestReview>(),
                IsApprovedGuest = false
            };
            
            var guest2 = new Guest()
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
                IsApprovedHost = false,
                ViaId = 654321,
                GuestReviews = new List<GuestReview>(),
                IsApprovedGuest = false
            };
            _guestList = new List<Guest>() {guest1, guest2};

            var guestRepository = new Mock<IGuestRepository>();
            guestRepository.Setup(ex => ex.GetAllNotApprovedGuestsAsync().Result).Returns(_guestList);
            var hostService = new Mock<IHostService>();
            hostService.Setup(ex => ex.GetHostByIdAsync(1).Result).Returns(host1);
            hostService.Setup(ex => ex.GetHostByIdAsync(2).Result).Returns(host2);
            _guestService = new GuestService(guestRepository.Object, 
                new CreateGuestValidator(guestRepository.Object, new Mock<IHostRepository>().Object));
        }
        
        [Test]
        public void GetNotNullListOfAllNotApprovedGuestDoesNotThrowExceptionTest()
        {
            Assert.DoesNotThrowAsync(()=> _guestService.GetAllNotApprovedGuestsAsync());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdateGuestRequestThrowsNoExceptionsTest(bool status)
        {
            var guestToUpdate = _guestList.First(h => h.Id == 1);
            guestToUpdate.IsApprovedGuest = status;
            Assert.DoesNotThrowAsync(()=> _guestService.UpdateGuestStatusAsync(guestToUpdate));
        }

        [Test]
        public void UpdateANullGuestThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _guestService.UpdateGuestStatusAsync(null));
        }
    }
}