using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace UnitTests
{
    [TestFixture]
    public class CreateResidenceTest
    {
        
        private IResidenceValidation _residenceValidation;
        
        private Address address;
        private City city;
        private IList<Facility> facilities;
        private IList<Rule> rules;
        private Residence residence;

        [SetUp]
        public void SetUp()
        {
            _residenceValidation = new ResidenceValidationImpl();

            city = new City()
            {
                Id = 1,
                CityName = "Horsens",
                ZipCode = 8700
            };

            address = new Address()
            {
                Id = 1,
                StreetName = "StreetNameTest",
                HouseNumber = "1A",
                StreetNumber = "2A",
                City = city
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
                Description = "DescriptionTest"
            });

            residence = new Residence()
            {
                Id = 1,
                Address = address,
                Description = "DescriptionTest",
                Type = "TypeTes",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "URLTest",
                AvailableFrom = new DateTime(2050, 11, 11),
                AvailableTo = new DateTime(2050, 11, 11)
            };
        }

        [Test]
        public void CreateResidenceSunnyScenarioTest()
        {
            Assert.DoesNotThrow(() => _residenceValidation.IsValidResidence(residence));
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
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [TestCase(null, "Test", "Test", "Test", 1111)]
        [TestCase("Test", null, "Test", "Test", 1111)]
        [TestCase("Test", "Test", "Test", null, 1111)]
        [TestCase("Test", "Test", "Test", "Test", -1111)]
        [TestCase("Test", "Test", null, "Test", 1111)]
        [TestCase("", "Test", "Test", "Test", 1111)]
        [TestCase("Test", "", "Test", "Test", 1111)]
        [TestCase("Test", "Test", "", "Test", 1111)]
        [TestCase("Test", "Test", "Test", "", 1111)]
        [TestCase("Test", "Test", "Test", "Test", 0)]
        public void CreateResidenceWithAnAddressWithInvalidAddressTest(string streetName, string houseNumber, string streetNumber, string cityName, int zipCode)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = streetName,
                HouseNumber = houseNumber,
                StreetNumber = streetNumber,
                City = new City()
                {
                    Id = 1,
                    CityName = cityName,
                    ZipCode = zipCode
                }
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };

            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidAddress(a));
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("1")]
        [TestCase("1a")]
        [TestCase("1A")]
        public void CreateResidenceWithAnAddressWithAnInvalidCityNameTest(string cityName)
        {
            Address a = new Address()
            {
                Id = 1,
                StreetName = "Test",
                HouseNumber = "Test",
                StreetNumber = "2A",
                City = new City()
                {
                    Id = 2,
                    CityName = cityName,
                    ZipCode = 1111
                }
            };
            Residence r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidAddress(a));
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [TestCase(null, "Test")]
        [TestCase("Test", null)]
        [TestCase("", "Test")]
        [TestCase("Test", "")]
        public void CreateResidenceWithAnInvalidTypeAndDescriptionTest(string type, string description)
        {
            Residence r = new Residence()
            {
                Id = 2,
                Address = address,
                Description = description,
                Type = type,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [TestCase(null, 1)]
        [TestCase(1, null)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void CreateResidenceWithAnInvalidPricePerNightAndAverageRatingTest(double avgRating, int ppn)
        {
            Residence r = new Residence()
            {
                Id = 2,
                Address = address,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = ppn,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [TestCase(null)]
        public void CreateResidenceWithANullIsAvailableTest(bool isAvp)
        {
            Residence r = new Residence()
            {
                Id = 2,
                Address = address,
                Description = "Test",
                Type = "Test",
                IsAvailable = isAvp,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
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
            Residence r = new Residence()
            {
                Id = 2,
                Address = address,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rs,
                Facilities = fs,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [TestCase( 2000, 11, 11)]
        [TestCase(2050, 11, 11)]
        public void CreateResidenceWithInvalidFromDateTest(int year, int month, int day)
        {
            Residence r = new Residence()
            {
                Id = 2,
                Address = address,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "Test",
                AvailableFrom = new DateTime(year, month, day),
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }
        
        [TestCase( 2000, 11, 11)]
        [TestCase(2050, 11, 11)]
        public void CreateResidenceWithInvalidToDateTest(int year, int month, int day)
        {
            Residence r = new Residence()
            {
                Id = 2,
                Address = address,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = rules,
                Facilities = facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = new DateTime(year, month, day)
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }
    }
}