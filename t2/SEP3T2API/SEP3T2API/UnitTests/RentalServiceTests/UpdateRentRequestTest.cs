using System;
using System.Collections.Generic;
using System.Globalization;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.RentalServiceTests
{
    [TestFixture]
    public class UpdateRentRequestTest
    {
        private Host _host;
        private Guest _guest;
        private Residence _residence;
        private IRentalService _rentalService;
        private Mock<IRentRequestRepository> _rentRequestRepository;

        [SetUp]
        public void SetUp()
        {
            _host = new Host()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "11111111",
                Email = "Test@test.tt",
                Password = "Aa12",
                HostReviews = new List<HostReview>(),
                ProfileImageUrl = "Test",
                Cpr = "1111111111",
                IsApprovedHost = true
            };
            _guest = new Guest()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "11111111",
                Email = "Test@test.tt",
                Password = "Aa12",
                HostReviews = new List<HostReview>(),
                ProfileImageUrl = "Test",
                Cpr = "1111111111",
                IsApprovedHost = true,
                ViaId = 111111,
                GuestReviews = new List<GuestReview>(),
                IsApprovedGuest = true
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
                Id = 1, 
                HouseNumber = "1t", 
                StreetName = "test", 
                StreetNumber = "1t"
            };
            _residence = new Residence()
            {
                Id = 1,
                Address = address,
                Description = "Test",
                Type = "Test",
                IsAvailable = true,
                PricePerNight = 11.1,
                Rules = new List<Rule>(),
                Facilities = new List<Facility>(),
                ImageUrl = "Test",
                AvailableFrom = CreateDate("11/11/2022"),
                AvailableTo = CreateDate("12/12/2022"),
                MaxNumberOfGuests = 5,
                Host = _host,
                ResidenceReviews = new List<ResidenceReview>()
            };
            _rentRequestRepository = new Mock<IRentRequestRepository>();
            CreateRentRequestValidator validator = new(_rentRequestRepository.Object);
            _rentalService = new RentalService(_rentRequestRepository.Object, validator);
        }

        [Test]
        public void UpdateRentRequestDoesNotThrowExceptionsTest()
        {
            var request = new RentRequest()
            {
                Id = 1,
                StartDate = CreateDate("11/11/2022"),
                EndDate = CreateDate("12/12/2022"),
                NumberOfGuests = 3,
                Status = RentRequestStatus.NOTANSWERED,
                Guest = _guest,
                Residence = _residence
            };
            var rentList = new List<RentRequest> {request};
            _rentRequestRepository.Setup<IEnumerable<RentRequest>>( exp =>  exp.GetAllAsync().Result).Returns(rentList);
            Assert.DoesNotThrowAsync(async () => await _rentalService.UpdateRentRequestStatusAsync(request));
        }

        [Test]
        public void UpdateRentRequestAsANullRentRequestThrowsArgumentExceptionTest()
        {
            RentRequest request = null;
            var rentList = new List<RentRequest> {request};
            _rentRequestRepository.Setup<IEnumerable<RentRequest>>( exp =>  exp.GetAllAsync().Result).Returns(rentList);
            Assert.ThrowsAsync<ArgumentException>(async () => await _rentalService.UpdateRentRequestStatusAsync(request));
        }

        /// <summary>
        /// Returns a DateTime object from a date string in format dd/MM/yyyy. 
        /// </summary>
        /// <param name="dateString">date string in dd/MM/yyyy format</param>
        /// <returns>dateString parsed to DateTime</returns>
        private DateTime CreateDate(string dateString)
        {
            return DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}