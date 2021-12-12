using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.GuestServiceTests
{
    [TestFixture]
    public class CreateGuestTest
    {
        private IGuestService _guestService;
        private Guest _validGuest;
        private Mock<IHostRepository> _hostRepository;
        private Mock<IGuestRepository> _guestRepository;

        [SetUp]
        public void SetUp()
        {
            _hostRepository = new Mock<IHostRepository>();
            _guestRepository = new Mock<IGuestRepository>();

            _validGuest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 303030, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            var hostService = new Mock<IHostService>();
            _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(4).Result).Returns(new Host());

            _guestService = new GuestServiceImpl(_guestRepository.Object,
                new CreateGuestValidator(_guestRepository.Object, _hostRepository.Object));
        }

        [Test]
        public void CreateGuest_GuestIsNull_ThrowsArgumentException()
        {
            Guest guest = null;
            TestCreateThrowsAsyncArgumentException(guest);
        }

        [Test]
        public void CreateGuest_HostDoesNotExist_ThrowsKeyNotFoundException()
        {
            Guest guest = new()
            {
                Id = 2, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 303030, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            Host nullHost = null;
            _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(2).Result).Returns(nullHost);

            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _guestService.CreateGuestAsync(guest));
        }

        [Test]
        public void CreateGuest_GuestWithSameStudentNumberExist_ThrowsArgumentException()
        {
            var guestWithSameStudentNumber = new Guest()
            {
                Id = 3, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = true,
                ProfileImageUrl = null
            };
            _guestRepository.Setup<IEnumerable<Guest>>(x => x.GetAllGuestsAsync().Result)
                .Returns(new List<Guest>() {guestWithSameStudentNumber});
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };

            TestCreateThrowsAsyncArgumentException(guest);
        }

        [Test]
        public void CreateGuest_ValidGuestWithUnusedStudentNumber_DoesNotThrow()
        {
            _guestRepository.Setup<Guest>(x => x.CreateGuestAsync(_validGuest).Result).Returns(_validGuest);
            Assert.DoesNotThrowAsync(async () => await _guestService.CreateGuestAsync(_validGuest));
        }


        [Test]
        [TestCase("testtest.com")]
        [TestCase("test@testcom")]
        [TestCase("test@testcom.")]
        [TestCase("testtestcom")]
        public void CreateGuest_InvalidEmail_ThrowsArgumentException(string email)
        {
            //Test caught bug where email was valid even if it did not contain a dot
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = email, Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 303030, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            TestCreateThrowsAsyncArgumentException(guest);
        }

        [Test]
        public void CreateGuest_ValidGuest_DoesNotThrow()
        {
            _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(4).Result).Returns(new Host() {Id = 4});
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 303030, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            _guestRepository.Setup<Guest>(x => x.CreateGuestAsync(guest).Result).Returns(guest);

            Assert.DoesNotThrowAsync(async () => await _guestService.CreateGuestAsync(guest));
        }

        [Test]
        [TestCase(29388)]
        [TestCase(2938866)]
        [TestCase(2)]
        [TestCase(299999999)]
        [TestCase(-29388)]
        public void CreateGuest_InvalidStudentNumber_ThrowsArgumentException(int studentNumber)
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = studentNumber, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            TestCreateThrowsAsyncArgumentException(guest);
        }

        [Test]
        public void CreateGuest_GuestIsNotApprovedHost_ThrowsArgumentException()
        {
            _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(4).Result)
                .Returns(new Host() {Id = 4, IsApprovedHost = false});
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = false, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            TestCreateThrowsAsyncArgumentException(guest);
        }


        [Test]
        public void CreateGuest_NullFirstName_ThrowsArgumentException()
        {
            _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(4).Result)
                .Returns(new Host() {Id = 4});
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = null,
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            TestCreateThrowsAsyncArgumentException(guest);
        }

        [Test]
        public void CreateGuest_NullLastName_ThrowsArgumentException()
        {
            _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(4).Result)
                .Returns(new Host() {Id = 4});
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = null,
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            TestCreateThrowsAsyncArgumentException(guest);
        }

        [Test]
        public void CreateGuest_NullPhoneNumber_ThrowsArgumentException()
        {   _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(4).Result)
                .Returns(new Host() {Id = 4});
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = null, ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            TestCreateThrowsAsyncArgumentException(guest);
        }

        [Test]
        public void CreateGuest_NullEmail_ThrowsArgumentException()
        {
            _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(4).Result)
                .Returns(new Host() {Id = 4});
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = null, Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            TestCreateThrowsAsyncArgumentException(guest);
        }
        
        [Test]
        public void CreateGuest_NullPassword_ThrowsArgumentException()
        {
            _hostRepository.Setup<Host>(x => x.GetHostByIdAsync(4).Result)
                .Returns(new Host() {Id = 4});
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = null, FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            TestCreateThrowsAsyncArgumentException(guest);
        }
        
        [Test]
        public void CreateGuest_NullCpr_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = null, Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            TestCreateThrowsAsyncArgumentException(guest);
        }
        /// <summary>
        /// Helper class to test if the async method CreateGuestAsync throws an ArgumentException
        /// </summary>
        /// <param name="guest">guest who is to be created</param>
        private void TestCreateThrowsAsyncArgumentException(Guest guest)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _guestService.CreateGuestAsync(guest));
        }
    }
}