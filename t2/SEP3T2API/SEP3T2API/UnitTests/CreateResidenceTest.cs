using System;
using System.Collections.Generic;
using System.Net.Http;
using HotChocolate.Types.Relay;
using NUnit.Core;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;

namespace UnitTests
{
    [TestFixture]
    public class CreateResidenceTest
    {
        private IResidenceService residenceService;
        private IResidenceRepository residenceRepository;
        private Address address;
        private IList<Facility> facilities;
        private IList<Rule> rules;
        private Residence residence;

        [SetUp]
        public void SetUp()
        {
            residenceRepository = new ResidenceRepositoryImpl();
            residenceService = new ResidenceServiceImpl(residenceRepository);
            
            address = new Address()
            {
                Id = 1,
                StreetName = "StreetNameTest",
                HouseNumber = "1A",
                CityName = "CityTest",
                StreetNumber = "2A",
                ZipCode = 1111
            };
            
            facilities = new List<Facility>();
            facilities.Add(new Facility
            {
                Id = 1,
                Name = "FacilityTest"
            });
            
            rules = new List<Rule>();
            rules.Add(new Rule()
            {
                Id = 1,
                Description = "DescriptionTest"
            });

            residence = new Residence()
            {
                Id = 1,
                Address = address,
                Description = "DescriptionTest",
                Type = "TypeTes",
                AverageRating = 1,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "URLTest",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            residenceRepository.CreateResidenceAsync(residence);
        }

        [Test]
        public void CreateResidenceSunnyScenarioTest()
        {
            //TODO find out why a nullPointer is being thrown
            Assert.DoesNotThrowAsync(() => residenceService.CreateResidenceAsync(residence));
        }

        [Test]
        public void CreateResidenceAddressWithNullAddressTest()
        {
            Residence r = new Residence()
            {
                Id = 2,
                Address = null,
                Description = "Test",
                Type = "Test",
                AverageRating = 1,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }

        [TestCase(null, "Test", "Test")]
        [TestCase("Test", null, "Test")]
        [TestCase("Test", "Test", null)]
        [TestCase("", "Test", "Test")]
        [TestCase("Test", "", "Test")]
        [TestCase("Test", "Test", "")]
        public void CreateResidenceWithAnAddressWithANullOrEmptyStreetNameHouseNumberAndStreetNumberTest(string streetName, string houseNumber, string streetNumber)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = streetName,
                HouseNumber = houseNumber,
                CityName = "CityTest",
                StreetNumber = streetNumber,
                ZipCode = 1111
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                AverageRating = 1,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };

            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(999)]
        [TestCase(null)]
        public void CreateResidenceWithAnAddressWithAZipCodeOutOfRangeTest(int zipCode)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = "Test",
                HouseNumber = "Test",
                CityName = "CityTest",
                StreetNumber = "2A",
                ZipCode = zipCode
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                AverageRating = 1,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }
        
        [TestCase(null)]
        [TestCase("")]
        [TestCase("1")]
        [TestCase("1A")]
        public void CreateResidenceWithAnAddressWithAnInvalidCityNameTest(string cityName)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = "Test",
                HouseNumber = "Test",
                CityName = cityName,
                StreetNumber = "2A",
                ZipCode = 1111
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                AverageRating = 1,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }

        [TestCase(null, "Test")]
        [TestCase("Test", null)]
        [TestCase("", "Test")]
        [TestCase("Test", "")]
        public void CreateResidenceWithAnInvalidTypeAndDescriptionTest(string type, string description)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = "Test",
                HouseNumber = "Test",
                CityName = "Test",
                StreetNumber = "2A",
                ZipCode = 1111
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = description,
                Type = type,
                AverageRating = 1,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }

        [TestCase(null, 1)]
        [TestCase(1, null)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void CreateResidenceWithAnInvalidPricePerNightAndAverageRatingTest(double avgRating, int ppn)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = "Test",
                HouseNumber = "Test",
                CityName = "Test",
                StreetNumber = "2A",
                ZipCode = 1111
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                AverageRating = avgRating,
                IsAvailable = false,
                PricePerNight = ppn,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }

        [TestCase(null)]
        public void CreateResidenceWithANullIsAvailableTest(bool isAvp)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = "Test",
                HouseNumber = "Test",
                CityName = "Test",
                StreetNumber = "2A",
                ZipCode = 1111
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                AverageRating = 1,
                IsAvailable = isAvp,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }

        [TestCase(null, "Test")]
        [TestCase("Test", null)]
        [TestCase("", "Test")]
        [TestCase("Test", "")]
        public void CreateResidenceWithInvalidRulesAndFacilitiesTest(string des, string name)
        {
            IList<Rule> rs = new List<Rule>();
            rs.Add(new Rule()
                {
                    Id = 2,
                    Description = des
                }
            );
            IList<Facility> fs = new List<Facility>();
            fs.Add(new Facility()
                {
                    Id = 2,
                    Name = name
                }
            );
            Address a = new Address()
            {
                Id = 1,
                StreetName = "Test",
                HouseNumber = "Test",
                CityName = "Test",
                StreetNumber = "2A",
                ZipCode = 1111
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                AverageRating = 1,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rs,
                Facilities = fs,
                ImageURL = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }

        [TestCase(null, null)]
        [TestCase("01.01.2000", "01.01.2000")]
        [TestCase("01.01.2050", "01.01.2050")]
        public void CreateResidenceWithInvalidFromAndToDatesTest(DateTime from, DateTime to)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = "Test",
                HouseNumber = "Test",
                CityName = "Test",
                StreetNumber = "2A",
                ZipCode = 1111
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                AverageRating = 1,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageURL = "Test",
                AvailableFrom = from,
                AvailableTo = to
            };
            Assert.ThrowsAsync<ArgumentException>(() => residenceRepository.CreateResidenceAsync(r));
            Assert.ThrowsAsync<ArgumentException>(() => residenceService.CreateResidenceAsync(r));
        }
    }
}