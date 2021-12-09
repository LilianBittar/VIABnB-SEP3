using System;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.CityServiceTest
{
    [TestFixture]
    public class CreateCityTest
    {
        private Mock<ICityRepository> _cityRepository;
        private ICityService _cityService;
        
        [SetUp]
        public void SetUp()
        {
            _cityRepository = new Mock<ICityRepository>();
            _cityService = new CityService(_cityRepository.Object, new CreateCityValidator()); 
        }
        [Test]
        public void CreateCity_ValidCity_DoesNotThrow()
        {
            City city = new()
            {
                CityName = "horsens", Id = 1, ZipCode = 8700
            };
            Assert.DoesNotThrowAsync(async ()=> await _cityService.CreateAsync(city));
        }
        
        [Test]
        public void CreateCity_CityIsNull_ThrowsArgumentException()
        {
            City city = null;
            AssertCreateThrowsAsyncArgumentException(city);
        }
        [Test]
        public void CreateCity_CityNameIsEmptyString_ThrowsArgumentException()
        {
            City city = new()
            {
                CityName = "", Id = 1, ZipCode = 8700
            };
            AssertCreateThrowsAsyncArgumentException(city);
        }
        
        [Test]
        public void CreateCity_CityNameIsWhiteSpaceOnly_ThrowsArgumentException()
        {
            City city = new()
            {
                CityName = "      ", Id = 1, ZipCode = 8700
            }; 
            AssertCreateThrowsAsyncArgumentException(city);
        }
        
        [Test]
        public void CreateCity_ZipCodeIsNegative_ThrowsArgumentException()
        {
            City city = new()
            {
                CityName = "Horsens", ZipCode = -8700, Id = 1
            };
            AssertCreateThrowsAsyncArgumentException(city);
            
        }
        [Test]
        [TestCase(870)]
        [TestCase(87)]
        [TestCase(87000)]
        [TestCase(8)]
        [TestCase(80000000)]
        public void CreateCity_ZipCodeIsNotFourDigits_ThrowsArgumentException(int zipCode)
        {
            City city = new()
            {
                CityName = "Horsens", ZipCode = zipCode, Id = 1
            };
            AssertCreateThrowsAsyncArgumentException(city);
            
        }
        
        [Test]
        public void CreateCity_CityNameIsNull_ThrowsArgumentException()
        {
            City city = new()
            {
                CityName = null, Id = 1, ZipCode = 8700
            }; 
        }

        private void AssertCreateThrowsAsyncArgumentException(City city)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _cityService.CreateAsync(city));
        }

        
    }
}