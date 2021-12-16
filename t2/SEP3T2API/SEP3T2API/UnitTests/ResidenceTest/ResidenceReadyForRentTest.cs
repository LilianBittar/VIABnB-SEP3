using System;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;

namespace UnitTests.ResidenceTest
{
    [TestFixture]
    public class ResidenceReadyForRentTest
    {
        private Residence _residence = new Residence();
        private IResidenceService _residenceService;
        private Mock<IResidenceRepository> _residenceRepository;
        private IAddressService _addressService;
        private ICityService _cityService;
        public ResidenceReadyForRentTest(IAddressService addressService, ICityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;
        }


        [SetUp]
        public void SetUp()
        {
            _residenceRepository = new Mock<IResidenceRepository>();
            _residenceService = new ResidenceService(_residenceRepository.Object,_cityService,_addressService);
        }
        
        [TestCase(1,3)]
        [TestCase(0,10)]
        [TestCase(3,60)]
        public void UpdateResidenceAvailabilityAsync_ExpectedValues_DoesNotThrow(int from,int to)
        {
            //arange
            _residence = new Residence()
            {
                AvailableFrom = DateTime.Today.AddDays(from),
                AvailableTo = DateTime.Today.AddDays(to)
            };

            //act and assert
            Assert.DoesNotThrowAsync(() => _residenceService.UpdateResidenceAvailabilityAsync(_residence));
        }
        
        
        [Test]
        public void UpdateResidenceAvailabilityAsync_FromDateIsNull_Throws()
        {
            //arange
            _residence = new Residence()
            {
                AvailableFrom = null,
                AvailableTo = DateTime.Today.AddDays(3)
            };

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAvailabilityAsync(_residence));
        }
        
        [Test]
        public void UpdateResidenceAvailabilityAsync_ToDateIsNull_Throws()
        {
            //arange
            _residence = new Residence()
            {
                AvailableFrom = DateTime.Today.AddDays(3),
                AvailableTo = null
            };

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAvailabilityAsync(_residence));
        }
        
        [TestCase(-2,1)]
        [TestCase(-100,-10)]
        [TestCase(-1,5)]
        public void UpdateResidenceAvailabilityAsync_RentPeriodInThePast_Throws(int from,int to)
        {
            //arange
            _residence = new Residence()
            {
                AvailableFrom = DateTime.Today.AddDays(from),
                AvailableTo = DateTime.Today.AddDays(to)
            };

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAvailabilityAsync(_residence));
        }
        
        [TestCase(5,4)]
        [TestCase(10,8)]
        [TestCase(3,2)]
        public void UpdateResidenceAvailabilityAsync_FromDateNotBeforeToDate_Throws(int from,int to)
        {
            //arange
            _residence = new Residence()
            {
                AvailableFrom = DateTime.Today.AddDays(from),
                AvailableTo = DateTime.Today.AddDays(to)
            };

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => _residenceService.UpdateResidenceAvailabilityAsync(_residence));
        }
    }
}