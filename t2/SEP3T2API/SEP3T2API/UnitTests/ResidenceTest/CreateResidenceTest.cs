using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace UnitTests.ResidenceTest
{
    [TestFixture]
    public class CreateResidenceTest
    {
        
        private IResidenceValidation _residenceValidation;
      
        
        private Address _address;
        private City _city;
        private IList<Facility> _facilities;
        private IList<Rule> _rules;
        private Residence _residence;

        [SetUp]
        public void SetUp()
        {
           
            _residenceValidation = new ResidenceValidation();

            _city = new City()
            {
                Id = 1,
                CityName = "Horsens",
                ZipCode = 8700
            };

            _address = new Address()
            {
                Id = 1,
                StreetName = "StreetNameTest",
                HouseNumber = "1A",
                StreetNumber = "2A",
                City = _city
            };
            
            _facilities = new List<Facility>();
            _facilities.Add(new Facility
            {
                Id = 1,
                Name = "FacilityTest"
            });
            
            _rules = new List<Rule>();
            _rules.Add(new Rule()
            {
                Description = "DescriptionTest"
            });

            _residence = new Residence()
            {
                Id = 1,
                Address = _address,
                Description = "DescriptionTest",
                Type = "TypeTes",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = _rules,
                Facilities = _facilities,
                ImageUrl = "URLTest",
                AvailableFrom = new DateTime(2050, 11, 11),
                AvailableTo = new DateTime(2050, 11, 12)
            };
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
                Rules = _rules,
                Facilities = _facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [TestCase(null, "Test", "Test", "Test", 1111)]
        [TestCase("Test", "Test", "Test", null, 1111)]
        [TestCase("Test", "Test", "Test", "Test", -1111)]
        [TestCase("Test", "Test", null, "Test", 1111)]
        [TestCase("", "Test", "Test", "Test", 1111)]
        [TestCase("Test", "Test", "", "Test", 1111)]
        [TestCase("Test", "Test", "Test", "", 1111)]
        [TestCase("Test", "Test", "Test", "Test", 0)]
        public void CreateResidenceWithAnAddressWithInvalidAddressTest(string streetName, string houseNumber, string streetNumber, string cityName, int zipCode)
        {
            var a = new Address()
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
            var r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = _rules,
                Facilities = _facilities,
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
            var a = new Address()
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
            var r = new Residence()
            {
                Id = 2,
                Address = a,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = _rules,
                Facilities = _facilities,
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
            var r = new Residence()
            {
                Id = 2,
                Address = _address,
                Description = description,
                Type = type,
                IsAvailable = false,
                PricePerNight = 1,
                Rules = _rules,
                Facilities = _facilities,
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void CreateResidenceWithAnInvalidPricePerNightAndAverageRatingTest( int ppn)
        {
            var r = new Residence()
            {
                Id = 2,
                Address = _address,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = ppn,
                Rules = _rules,
                Facilities = _facilities,
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
            var r = new Residence()
            {
                Id = 2,
                Address = _address,
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
            var r = new Residence()
            {
                Id = 2,
                Address = _address,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = _rules,
                Facilities = _facilities,
                ImageUrl = "Test",
                AvailableFrom = new DateTime(year, month, day),
                AvailableTo = DateTime.Now
            };
            Assert.Throws<ArgumentException>(() => _residenceValidation.IsValidResidence(r));
        }

        [Test]
        public void CreateResidence_HostIsNotApproved_ThrowsArgumentException()
        {

            var host = new Host()
            {
                Cpr = "1111111111",
                Email = "test@test.com",
                Id = 1,
                Password = "Test123123",
                FirstName = "Test",
                HostReviews = new List<HostReview>(),
                LastName = "Test", PhoneNumber = "88888888", IsApprovedHost = false, ProfileImageUrl = "test"
            };
            var r = new Residence()
            {
                Id = 2,
                Address = _address,
                Description = "Test",
                Type = "Test",
                IsAvailable = false,
                PricePerNight = 1,
                Rules = _rules,
                Facilities = _facilities,
                Host = host, 
                ImageUrl = "Test",
                AvailableFrom = DateTime.Now.AddDays(1),
                AvailableTo = DateTime.Now.AddDays(7)
            };
            Assert.Throws<ArgumentException>( () =>  _residenceValidation.IsValidResidence(r));
        }
    }
}