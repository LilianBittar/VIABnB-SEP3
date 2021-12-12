using System;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.AddressServiceTest
{
    [TestFixture]
    public class CreateAddressTest
    {
        private Mock<IAddressRepository> _addressRepository;
        private IAddressService _addressService;

        [SetUp]
        public void SetUp()
        {
            _addressRepository = new Mock<IAddressRepository>();
            _addressService = new AddressService(_addressRepository.Object, new CreateAddressValidator());
        }
        [Test]
        public void CreateAddress_ValidAddressDoesNotThrow()
        {
            City city = new()
            {
                Id = 1, CityName = "Horsens", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1.th", StreetName = "Test", StreetNumber = "1t"
            };
            Assert.DoesNotThrowAsync(async () =>await _addressService.CreateAddressAsync(address));
        }
        
        [Test]
        public void CreateAddress_NullAddress_ThrowsArgumentException()
        {
            Address address = null; 
            TestAssertCreateThrowsArgumentExceptionAsync(address);
        }

        [Test]
        public void CreateAddress_StreetNameNull_ThrowsArgumentException()
        {
            City city = new()
            {
                Id = 1, CityName = "Horsens", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1.th", StreetName =null, StreetNumber ="1T"
            };
            TestAssertCreateThrowsArgumentExceptionAsync(address);
        }  
        [Test]
        public void CreateAddress_StreetNumberNull_ThrowsArgumentException()
        {
            City city = new()
            {
                Id = 1, CityName = "Horsens", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1.th", StreetName = "Test", StreetNumber = null 
            };
            TestAssertCreateThrowsArgumentExceptionAsync(address);
        }
        
        
        [Test]
        public void CreateAddress_StreetNameEmptyString_ThrowsArgumentException()
        {
            City city = new()
            {
                Id = 1, CityName = "Horsens", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1.th", StreetName = "", StreetNumber = "1T" 
            };
            TestAssertCreateThrowsArgumentExceptionAsync(address);
        }
        
        [Test]
        public void CreateAddress_StreetNumberEmptyString_ThrowsArgumentException()
        {
            City city = new()
            {
                Id = 1, CityName = "Horsens", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1.th", StreetName = "Test", StreetNumber = "" 
            };
            TestAssertCreateThrowsArgumentExceptionAsync(address);
        }
        
        [Test]
        public void CreateAddress_StreetNameIsWhiteSpaceOnly_ThrowsArgumentException()
        {
            City city = new()
            {
                Id = 1, CityName = "Horsens", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1.th", StreetName = "    ", StreetNumber = "1t" 
            };
            TestAssertCreateThrowsArgumentExceptionAsync(address); 
        }
        [Test]
        public void CreateAddress_StreetNumberIsWhiteSpaceOnly_ThrowsArgumentException()
        {
            City city = new()
            {
                Id = 1, CityName = "Horsens", ZipCode = 8700
            };
            Address address = new()
            {
                City = city, Id = 1, HouseNumber = "1.th", StreetName = "Test", StreetNumber = "        " 
            };
            TestAssertCreateThrowsArgumentExceptionAsync(address); 
        }

        private void TestAssertCreateThrowsArgumentExceptionAsync(Address address)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _addressService.CreateAddressAsync(address));
        }
    }
}