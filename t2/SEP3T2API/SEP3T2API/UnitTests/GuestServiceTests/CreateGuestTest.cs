using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;

namespace UnitTests.GuestServiceTests
{
    [TestFixture]
    public class CreateGuestTest
    {
        private IGuestService _guestService;

        [SetUp]
        public void SetUp()
        {
            Guest guestWithSameStudentNumber = new Guest()
            {
                Id = 3, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = true,
                ProfileImageUrl = null
            };
            Host nullHost = null; 
            //Mock setup for test where guest have same student number
            var guestRepository = new Mock<IGuestRepository>();
            guestRepository.Setup<IList<Guest>>(x => x.GetAllGuests().Result)
                .Returns(new List<Guest>() {guestWithSameStudentNumber});
            //Mock setup for test where host does not exist in the system 
            var hostService = new Mock<IHostService>();
            hostService.Setup<Host>(x => x.GetHostById(2).Result).Returns(nullHost);
            hostService.Setup<Host>(x => x.GetHostById(4).Result).Returns(new Host());
            _guestService = new GuestServiceImpl(guestRepository.Object, hostService.Object); 
        }

        [Test]
        public void CreateGuest_GuestIsNull_ThrowsArgumentException()
        {
            Guest guest = null;
            Assert.ThrowsAsync<ArgumentException>(async () => await _guestService.CreateGuestAsync(null)); 
        }

        [Test]
        public void CreateGuest_HostDoesNotExist_ThrowsKeyNotFoundException()
        {
            //This test caught an bug where NullReferenceException was thrown instead of KeyNotfound
            Guest guest = new()
            {
                Id = 2, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 303030, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };

            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _guestService.CreateGuestAsync(guest)); 
        }

        [Test]
        public void CreateGuest_GuestWithSameStudentNumberExist_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await _guestService.CreateGuestAsync(guest)); 
        }

        [Test]
        public void CreateGuest_ValidGuestWithUnusedStudentNumber_DoesNotThrow()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 303030, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            Assert.DoesNotThrowAsync(async () => await _guestService.CreateGuestAsync(guest));
        }
    }
}