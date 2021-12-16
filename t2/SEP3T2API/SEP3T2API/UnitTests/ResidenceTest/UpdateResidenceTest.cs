using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.ResidenceTest
{
    [TestFixture]
    public class UpdateResidenceTest
    {
        private City _city;
        private Address _address;
        private Host _host;
        private Residence _residence;
        private IResidenceService _residenceService;
        private ICityService _cityService;
        private IAddressService _addressService;
        private Mock<IAddressRepository> _addressRepository;
        private Mock<ICityRepository> _cityRepository;
        private Mock<IResidenceRepository> _residenceRepository;

        [SetUp]
        public void SetUp()
        {
            _residenceRepository = new Mock<IResidenceRepository>();
            _cityRepository = new Mock<ICityRepository>();
            _addressRepository = new Mock<IAddressRepository>();
            _addressService = new AddressService(_addressRepository.Object, new CreateAddressValidator());
            _cityService = new CityService(_cityRepository.Object, new CreateCityValidator());
            _residenceService = new ResidenceService(_residenceRepository.Object, _cityService, _addressService);
            _city = new City()
            {
                Id = 1,
                CityName = "Test",
                ZipCode = 1111
            };
            _address = new Address()
            {
                Id = 1,
                StreetName = "Test",
                StreetNumber = "1",
                HouseNumber = "1D",
                City = _city
            };
            _host = new Host()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Cpr = "1111111111",
                Email = "Test@test.tt",
                HostReviews = new List<HostReview>(),
                IsApprovedHost = true,
                Password = "Aa1111111",
                PhoneNumber = "11111111",
                ProfileImageUrl = "Test"
            };
        }

        [Test]
        public void UpdateResidenceDoesNotThrowExceptionsTest()
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now,
                Description = "Test",
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = "Test",
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 300,
                MaxNumberOfGuests = 33
            };
            Assert.DoesNotThrowAsync(()=> _residenceService.UpdateResidenceAsync(_residence));
        }

        [TestCase(-2,1)]
        [TestCase(-100,-10)]
        [TestCase(-1,5)]
        public void UpdateResidenceWithInvalidDateToThrowsExceptionTest(int from, int to)
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = DateTime.Now.AddDays(from),
                AvailableTo = DateTime.Now.AddDays(to),
                Description = "Test",
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = "Test",
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 300,
                MaxNumberOfGuests = 33
            };
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAsync(_residence));
        }

        [Test]
        public void UpdateResidenceWithANullAvailableFromThrowsExceptionTest()
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = null,
                AvailableTo = DateTime.Now,
                Description = "Test",
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = "Test",
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 300,
                MaxNumberOfGuests = 33
            };
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAsync(_residence));
        }
        
        [Test]
        public void UpdateResidenceWithANullAvailableToThrowsExceptionTest()
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = DateTime.Now,
                AvailableTo = null,
                Description = "Test",
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = "Test",
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 300,
                MaxNumberOfGuests = 33
            };
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAsync(_residence));
        }

        [TestCase(5,4)]
        [TestCase(10,8)]
        [TestCase(3,2)]
        public void UpdateResidenceWhereFromDateNotBeforeToDateThrowsExceptionTest(int from,int to)
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = DateTime.Today.AddDays(from),
                AvailableTo = DateTime.Now.AddDays(to),
                Description = "Test",
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = "Test",
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 300,
                MaxNumberOfGuests = 33
            };
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAsync(_residence));
        }

        [TestCase(null)]
        [TestCase("")]
        public void UpdateResidenceWithInvalidDescriptionThrowsExceptionTest(string description)
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = DateTime.Today,
                AvailableTo = DateTime.Now,
                Description = description,
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = "Test",
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 300,
                MaxNumberOfGuests = 33
            };
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAsync(_residence));
        }
        
        [TestCase(null)]
        [TestCase("")]
        public void UpdateResidenceWithInvalidTypeThrowsExceptionTest(string type)
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = DateTime.Today,
                AvailableTo = DateTime.Now,
                Description = "Test",
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = type,
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 300,
                MaxNumberOfGuests = 33
            };
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAsync(_residence));
        }

        [TestCase(-100)]
        [TestCase(-10)]
        [TestCase(-1)]
        public void UpdateResidenceWithInvalidPricePerNightThrowsExceptionTest(int price)
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = DateTime.Today,
                AvailableTo = DateTime.Now,
                Description = "Test",
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = "Test",
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = price,
                MaxNumberOfGuests = 33
            };
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAsync(_residence));
        }

        [TestCase(-100)]
        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        public void UpdateResidenceWithInvalidMaxNumberOfGuestsThrowsExceptionsTest(int maxNumberOfGuests)
        {
            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                AvailableFrom = DateTime.Today,
                AvailableTo = DateTime.Now,
                Description = "Test",
                Facilities = new List<Facility>(),
                Host = _host,
                ImageUrl = "Test",
                Type = "Test",
                IsAvailable = true,
                Rules = new List<Rule>(),
                ResidenceReviews = new List<ResidenceReview>(),
                PricePerNight = 300,
                MaxNumberOfGuests = maxNumberOfGuests
            };
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAsync(_residence));
        }
    }
}