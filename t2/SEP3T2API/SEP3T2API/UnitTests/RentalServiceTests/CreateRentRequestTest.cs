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
    public class CreateRentRequestTest
    {
        private Host _host;
        private Residence _residence;
        private IRentalService _rentalService;
        private Mock<IRentRequestRepository> _rentRequestRepository;
        private Guest _validGuest;

        [SetUp]
        public void SetUp()
        {
            _host = new Host
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
            _validGuest = new Guest()
            {
                Cpr = "111111-1111",
                Email = "test@test.com", Id = 1, Password = "test123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedGuest = true, IsApprovedHost = true,
                ProfileImageUrl = "test"
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
            _residence = new Residence()
            {
                Address = address, Description = "test", Facilities = new List<Facility>(), Host = _host,
                Id = 1, Rules = new List<Rule>(), Type = "test",
                AvailableFrom = CreateDate("01/12/2021"),
                AvailableTo = CreateDate("31/12/2021"),
                ImageUrl = null, IsAvailable = true, ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 2000, MaxNumberOfGuests = 4
            };

            _rentRequestRepository = new Mock<IRentRequestRepository>();
            CreateRentRequestValidator validator = new(_rentRequestRepository.Object);
            _rentalService = new RentalService(_rentRequestRepository.Object, validator);
        }

        [Test]
        public void CreateRentRequest_ValidTest_DoesNotThrow()
        {
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = CreateDate("01/12/2021"),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = CreateDate("31/12/2021"),
                NumberOfGuests = 2
            };
            List<RentRequest> emptyRentRequestList = new();
            _rentRequestRepository.Setup<IEnumerable<RentRequest>>(x => x.GetAllAsync().Result)
                .Returns(emptyRentRequestList);
            Assert.DoesNotThrowAsync(async () => await _rentalService.CreateRentRequest(request));
        }

        [Test]
        public void CreateRentRequest_NullRequest_ThrowsArgumentException()
        {
            RentRequest request = null;
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void CreateRentRequest_NumberOfGuestsIsLessThanOne_ThrowsArgumentException(int numberOfGuests)
        {
            //This test caught a bug where null was returned instead of throwing ArgumentException. 
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = CreateDate("02/12/2021"),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = CreateDate("30/12/2021"),
                NumberOfGuests = numberOfGuests
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [TestCase(5)]
        [TestCase(6)]
        [TestCase(100)]
        public void CreateRentRequest_NumberOfGuestsExceedsHostsMaxNumberOfGuests_ThrowsArgumentException(
            int numberOfGuests)
        {
            //This test caught a bug where null was returned instead of throwing ArgumentException. 
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = CreateDate("02/12/2021"),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = CreateDate("30/12/2021"),
                NumberOfGuests = numberOfGuests
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        public void CreateRentRequest_EndDateAndStartDateIsTheSame_ThrowsArgumentException()
        {
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = CreateDate("02/12/2021"),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = CreateDate("02/12/2021"),
                NumberOfGuests = 2
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        [TestCase("30/11/2021")]
        [TestCase("29/11/2021")]
        [TestCase("20/01/2021")]
        public void CreateRentRequest_StartDateIsEarlierThanAvailableFrom_ThrowsArgumentException(
            string startDateString)
        {
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = CreateDate(startDateString),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = CreateDate("31/12/2021"),
                NumberOfGuests = 2
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        [TestCase("01/01/2022")]
        [TestCase("02/01/2022")]
        [TestCase("31/12/2022")]
        public void CreateRentRequest_EndDateIsLaterThanAvailableTo_ThrowsArgumentException(string startDateString)
        {
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = CreateDate(startDateString),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = CreateDate("31/12/2021"),
                NumberOfGuests = 2
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        public void CreateRentRequest_StartDateIsOneDayEarlierThanToday()
        {
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = DateTime.Now.AddDays(-1),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = DateTime.Now.AddDays(20),
                NumberOfGuests = 2
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        public void CreateRentRequest_StartDateIsManyDaysEarlierThanToday()
        {
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = DateTime.Now.AddDays(-30),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = DateTime.Now.AddDays(20),
                NumberOfGuests = 2
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        public void CreateRentRequest_EndDateIsOneDayEarlierThanToday_ThrowsArgumentException()
        {
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = DateTime.Now.AddDays(1),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = DateTime.Now.AddDays(-1),
                NumberOfGuests = 2
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        public void CreateRentRequest_ResidenceIsUnAvailable_ThrowsArgumentException()
        {
            _residence.IsAvailable = false;

            RentRequest request = new()
            {
                Guest = _validGuest, Id = 1, StartDate = CreateDate("02/12/2021"),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = CreateDate("30/12/2021"),
                NumberOfGuests = 2
            };
            TestCreateThrowsArgumentExceptionAsync(request);
        }

        [Test]
        public void CreateRentRequest_ResidenceHasAnAlreadyApprovedRentRequestInSameRentPeriod_ThrowsArgumentException()
        {
            //This test caught an bug where the wrong id was being compared in CreateRentRequestValidator resulting in null being returned. 
            Guest otherGuest = new()
            {
                Cpr = "111111-1112",
                Email = "test@test.com", Id = 2, Password = "test123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedGuest = true, IsApprovedHost = true,
                ProfileImageUrl = "test"
            };
            RentRequest approvedRequestInSamePeriod = new()
            {
                Guest = otherGuest, Id = 2, StartDate = CreateDate("02/12/2021"),
                Residence = _residence, Status = RentRequestStatus.Approved, EndDate = CreateDate("30/12/2021"),
                NumberOfGuests = 2
            };

            _rentRequestRepository.Setup<IEnumerable<RentRequest>>(x => x.GetAllAsync().Result)
                .Returns(new List<RentRequest>() {approvedRequestInSamePeriod});
            
            RentRequest request = new()
            {
                Guest = _validGuest, Id = 3, StartDate = CreateDate("02/12/2021"),
                Residence = _residence, Status = RentRequestStatus.NotAnswered, EndDate = CreateDate("30/12/2021"),
                NumberOfGuests = 2
            };
            
            TestCreateThrowsArgumentExceptionAsync(request);
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

        /// <summary>
        /// Helper method that tests if the async method CreateRentRequest in IRentalService throws the exception ArgumentException.  
        /// </summary>
        /// <param name="request">Request being tested</param>
        private void TestCreateThrowsArgumentExceptionAsync(RentRequest request)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _rentalService.CreateRentRequest(request));
        }
    }
}