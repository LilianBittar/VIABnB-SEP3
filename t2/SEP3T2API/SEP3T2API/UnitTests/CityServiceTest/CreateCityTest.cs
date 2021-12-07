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
        public void CreateCity_CityIsNull_ThrowsArgumentException()
        {
            City city = null;
            Assert.ThrowsAsync<ArgumentException>(async () => await _cityService.CreateAsync(city));
        }

    }
}