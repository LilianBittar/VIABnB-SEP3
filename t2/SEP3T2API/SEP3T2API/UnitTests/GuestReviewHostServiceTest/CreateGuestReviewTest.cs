using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.GuestReviewHostServiceTest
{
    [TestFixture]
    public class CreateGuestReviewTest
    {
        private Mock<IRentalService> _rentalService;
        private Mock<IGuestReviewRepository> _guestReviewHostRepository;
        private CreateGuestReviewValidation _validator;
        private GuestReviewService _guestReviewService;

        [SetUp]
        public void SetUp()
        {
            _rentalService = new Mock<IRentalService>();
            _guestReviewHostRepository = new Mock<IGuestReviewRepository>();
            _validator = new CreateGuestReviewValidation(_rentalService.Object);
            _guestReviewService = new GuestReviewService(_guestReviewHostRepository.Object, _validator);
        }


        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(100)]
        public void CreateGuestReview_InvalidRating_ThrowsArgumentException(int rating)
        {
            GuestReview guestReview = new GuestReview()
            {
                CreatedDate = new DateTime(),
                GuestId = 1,
                HostId = 3,
                Rating = rating,
                Text = "Was oki doki."
            };
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _guestReviewService.CreateGuestReviewAsync(guestReview));
        }


        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        public void CreateGuestReview_ValidRating_DoesNotThrow(int rating)
        {
            GuestReview guestReview = new GuestReview()
            {
                CreatedDate = new DateTime(),
                GuestId = 1,
                HostId = 3,
                Rating = rating,
                Text = "Was oki doki."
            };
            Assert.DoesNotThrowAsync(async () =>
                await _guestReviewService.CreateGuestReviewAsync(guestReview));
        }

        [Test]
        public void CreateGuestReview_GuestHasNeverRentedResidenceOwnedByHost_ThrowsArgumentException()
        {
            GuestReview guestReview = new()
            {
                CreatedDate = new DateTime(),
                GuestId = 1,
                HostId = 3,
                Rating = 5,
                Text = "it was decent I guess?"
            };
            List<RentRequest> emptyRentRequestList = new();
            _rentalService
                .Setup<IEnumerable<RentRequest>>(x => x.GetRentRequestsByGuestIdAsync(guestReview.GuestId).Result)
                .Returns(emptyRentRequestList);
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _guestReviewService.CreateGuestReviewAsync(guestReview));
        }

        [TestCase(RentRequestStatus.NOTANSWERED)]
        [TestCase(RentRequestStatus.NOTAPPROVED)]
        public void CreateGuestReview_GuestHasNotApprovedRentRequestForResidenceOwnedByHost_ThrowsArgumentException(
            RentRequestStatus status)
        {
            var host = new Host
            {
                Cpr = "111111-1111",
                Email = "test@test.test",
                Id = 1,
                Password = "test123",
                FirstName = "test",
                HostReviews = new List<HostReview>(),
                LastName = "test",
                PhoneNumber = "+4588888888",
                IsApprovedHost = true, ProfileImageUrl = "https//test.com/test/test.png"
            };
            City city = new()
            {
                Id = 1,
                CityName = "Test",
                ZipCode = 8700
            };
            Address address = new()
            {
                City = city,
                Id = 1, HouseNumber = "1t", StreetName = "test", StreetNumber = "1t"
            };
            Residence residence = new()
            {
                Address = address, Description = "test", Facilities = new List<Facility>(), Host = host,
                Id = 1, Rules = new List<Rule>(), Type = "test",
                AvailableFrom = DateTime.UtcNow,
                AvailableTo = DateTime.UtcNow.AddDays(31),
                ImageUrl = null, IsAvailable = true, ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 2000, MaxNumberOfGuests = 4
            };
            var guest = new Guest()
            {
                Cpr = "111111-1111",
                Email = "test@test.com", Id = 1, Password = "test123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedGuest = true, IsApprovedHost = true,
                ProfileImageUrl = "test"
            };
            var rentRequestWithInvalidStatus = new RentRequest()
            {
                Guest = guest, Id = 1, Residence = residence, Status = status, StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow.AddDays(3), NumberOfGuests = 1, RequestCreationDate = DateTime.UtcNow
            };
            var review = new GuestReview()
            {
                Rating = 1, Text = "It was great...", CreatedDate = DateTime.Now, GuestId = guest.Id, HostId = host.Id
            };
            _rentalService.Setup<IEnumerable<RentRequest>>(x => x.GetRentRequestsByGuestIdAsync(guest.Id).Result)
                .Returns(new List<RentRequest>() {rentRequestWithInvalidStatus});
            Assert.ThrowsAsync<ArgumentException>(async () => await _guestReviewService.CreateGuestReviewAsync(review));
        }
    }
}