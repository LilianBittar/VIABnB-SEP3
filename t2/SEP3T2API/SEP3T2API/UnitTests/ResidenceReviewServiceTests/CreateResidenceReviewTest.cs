using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.ResidenceReviewServiceTests
{
    [TestFixture]
    public class CreateResidenceReviewTest
    {
        private Guest _guest;
        private Residence _residence;
        private Mock<IResidenceReviewRepository> _residenceReviewRepository;
        private Mock<IRentRequestRepository> _rentRequestRepository;
        private CreateResidenceReviewValidator _validator;
        private ResidenceReviewService _residenceReviewService;

        [SetUp]
        public void SetUp()
        {
            City city = new()
            {
                Id = 1, CityName = "Test", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1t", StreetName = "test", StreetNumber = "1t"
            };
            Host host = new()
            {
                Cpr = "11111111", Email = "test@test.test", Id = 1, Password = "Test123", FirstName = "Test",
                HostReviews = new List<HostReview>(), LastName = "Test", PhoneNumber = "+4588888888",
                IsApprovedHost = true, ProfileImageUrl = "test"
            };
            _residence = new Residence
            {
                Address = address, Description = "test", Facilities = new List<Facility>(), Host = host, Id = 1,
                Rules = new List<Rule>(), Type = "test", AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now.AddDays(7), ImageUrl = "test", IsAvailable = true,
                ResidenceReviews = new List<ResidenceReview>(), PricePerNight = 2000, MaxNumberOfGuests = 2
            };
            _guest = new Guest
            {
                Cpr = "22222222", Email = "test@test.com", Id = 2, Password = "Test123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4511111111", ViaId = 293886, IsApprovedGuest = true, IsApprovedHost = true,
                ProfileImageUrl = "test"
            };
            _residenceReviewRepository = new Mock<IResidenceReviewRepository>();
            _rentRequestRepository = new Mock<IRentRequestRepository>();

            _validator =
                new CreateResidenceReviewValidator(_rentRequestRepository.Object);
            _residenceReviewService = new ResidenceReviewService(_residenceReviewRepository.Object, _validator);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(100)]
        public void CreateResidenceReview_InvalidRating_ThrowsArgumentException(int rating)
        {
            RentRequest existingRentRequest = new()
            {
                Guest = _guest, Id = 1, Residence = _residence, Status = RentRequestStatus.APPROVED,
                StartDate = DateTime.Now, EndDate = DateTime.Today.AddDays(2), NumberOfGuests = 1,
                RequestCreationDate = DateTime.Now
            };
            _rentRequestRepository.Setup(x => x.GetRentRequestsByGuestIdAsync(_guest.Id).Result)
                .Returns(new List<RentRequest>() {existingRentRequest});
            ResidenceReview review = new()
            {
                Rating = rating, CreatedDate = DateTime.Now, ReviewText = "test", GuestViaId = _guest.ViaId
            };
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _residenceReviewService.CreateResidenceReviewAsync(_residence, review));
        }


        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        public void CreateResidenceReview_ValidRating_DoesNotThrow(int rating)
        {
            RentRequest existingRentRequest = new()
            {
                Guest = _guest, Id = 1, Residence = _residence, Status = RentRequestStatus.APPROVED,
                StartDate = DateTime.Now, EndDate = DateTime.Today.AddDays(2), NumberOfGuests = 1,
                RequestCreationDate = DateTime.Now
            };
            _rentRequestRepository.Setup<IEnumerable<RentRequest>>(x => x.GetRentRequestsByViaIdAsync(_guest.ViaId).Result)
                .Returns(new List<RentRequest>() {existingRentRequest});
            ResidenceReview review = new()
            {
                Rating = rating, CreatedDate = DateTime.Now, ReviewText = "test", GuestViaId = _guest.ViaId
            };
            Assert.DoesNotThrowAsync(async () => await _residenceReviewService.CreateResidenceReviewAsync(_residence, review));
        }

        [Test]
        [TestCase(RentRequestStatus.NOTANSWERED)]
        [TestCase(RentRequestStatus.NOTAPPROVED)]
        public void CreateResidenceReview_GuestHasNoneApprovedRentRequestsForResidence_ThrowsArgumentException(
            RentRequestStatus status)
        {
            RentRequest existingRentRequest = new()
            {
                Guest = _guest, Id = 1, Residence = _residence, Status = status,
                StartDate = DateTime.Now, EndDate = DateTime.Today.AddDays(2), NumberOfGuests = 1,
                RequestCreationDate = DateTime.Now
            };
            _rentRequestRepository.Setup<IEnumerable<RentRequest>>(x => x.GetRentRequestsByViaIdAsync(_guest.ViaId).Result)
                .Returns(new List<RentRequest>() {existingRentRequest});
            ResidenceReview review = new()
            {
                Rating = 1, CreatedDate = DateTime.Now, ReviewText = "test", GuestViaId = _guest.ViaId
            };
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _residenceReviewService.CreateResidenceReviewAsync(_residence, review));
        }

        [Test]
        public void CreateResidenceReview_GuestHasNoRentRequestsForResidence_ThrowsArgumentException()
        {
            City city = new()
            {
                Id = 1, CityName = "Test", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1t", StreetName = "test", StreetNumber = "1t"
            };
            Host host = new()
            {
                Cpr = "11111111", Email = "test@test.test", Id = 1, Password = "Test123", FirstName = "Test",
                HostReviews = new List<HostReview>(), LastName = "Test", PhoneNumber = "+4588888888",
                IsApprovedHost = true, ProfileImageUrl = "test"
            };
            Residence otherResidence = new()
            {
                Address = address, Description = "test2", Facilities = new List<Facility>(), Host = host, Id = 2,
                Rules = new List<Rule>(), Type = "test2", AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now.AddDays(7), ImageUrl = "test", IsAvailable = true,
                ResidenceReviews = new List<ResidenceReview>(), PricePerNight = 2000, MaxNumberOfGuests = 2
            };
            RentRequest existingRentRequest = new()
            {
                Guest = _guest, Id = 1, Residence = otherResidence, Status = RentRequestStatus.APPROVED,
                StartDate = DateTime.Now, EndDate = DateTime.Today.AddDays(2), NumberOfGuests = 1,
                RequestCreationDate = DateTime.Now
            };
            _rentRequestRepository.Setup<IEnumerable<RentRequest>>(x => x.GetRentRequestsByViaIdAsync(_guest.ViaId).Result)
                .Returns(new List<RentRequest>() {existingRentRequest});
            ResidenceReview review = new()
            {
                Rating = 1, CreatedDate = DateTime.Now, ReviewText = "test", GuestViaId = _guest.ViaId
            };
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _residenceReviewService.CreateResidenceReviewAsync(_residence, review));
        }
    }
}