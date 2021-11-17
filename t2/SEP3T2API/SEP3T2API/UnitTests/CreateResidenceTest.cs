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
        private IList<Facility> facilities;
        private IList<Rule> rules;
        private Residence residence;

        [SetUp]
        public void SetUp()
        {
            _residenceValidation = new ResidenceValidationImpl();

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
                AverageRating = 1,
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
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };

            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidAddress(a));
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
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
                AverageRating = 1,
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
                AverageRating = avgRating,
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
                AverageRating = 1,
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
            Residence r = new Residence()
            {
                Id = 2,
                Address = address,
                Description = "Test",
                Type = "Test",
                AverageRating = 1,
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
                AverageRating = 1,
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
                AverageRating = 1,
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