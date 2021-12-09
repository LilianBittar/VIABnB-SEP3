using System;
using System.Globalization;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;

namespace UnitTests
{
    [TestFixture]
    public class ResidenceReadyForRentTest
    {
        private Residence residence = new Residence();
        private IResidenceService ResidenceService;
        private Mock<IResidenceRepository> ResidenceRepository;
        private IAddressService _addressService;
        private ICityService _cityService;
        private DateTime _dateTime;

        
        
        [SetUp]
        public void SetUp()
        {
            ResidenceRepository = new Mock<IResidenceRepository>();
            ResidenceService = new ResidenceServiceImpl(ResidenceRepository.Object,_cityService,_addressService);
            _dateTime = DateTime.Today.AddDays(1);
        }
        
        [TestCase(1,3)]
        [TestCase(0,10)]
        [TestCase(3,60)]
        public void UpdateResidenceAvailabilityAsync_ExpectedValues_DoesNotThrow(int from,int to)
        {
            //arange
            residence = new Residence()
            {
               AvailableFrom = DateTime.Today.AddDays(from),
               AvailableTo = DateTime.Today.AddDays(to)
            };

            //act and assert
            Assert.DoesNotThrowAsync(() => ResidenceService.UpdateResidenceAvailabilityAsync(residence));
        }
        
        
        [Test]
        public void UpdateResidenceAvailabilityAsync_FromDateIsNull_Throws()
        {
            //arange
            residence = new Residence()
            {
                AvailableFrom = null,
                AvailableTo = DateTime.Today.AddDays(3)
            };

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => ResidenceService.UpdateResidenceAvailabilityAsync(residence));
        }
        
        [Test]
        public void UpdateResidenceAvailabilityAsync_ToDateIsNull_Throws()
        {
            //arange
            residence = new Residence()
            {
                AvailableFrom = DateTime.Today.AddDays(3),
                AvailableTo = null
            };

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => ResidenceService.UpdateResidenceAvailabilityAsync(residence));
        }
        
        [TestCase(-2,1)]
        [TestCase(-100,-10)]
        [TestCase(-1,5)]
        public void UpdateResidenceAvailabilityAsync_RentPeriodInThePast_Throws(int from,int to)
        {
            //arange
            residence = new Residence()
            {
                AvailableFrom = DateTime.Today.AddDays(from),
                AvailableTo = DateTime.Today.AddDays(to)
            };

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => ResidenceService.UpdateResidenceAvailabilityAsync(residence));
        }
        
        [TestCase(5,4)]
        [TestCase(10,8)]
        [TestCase(3,2)]
        public void UpdateResidenceAvailabilityAsync_FromDateNotBeforeToDate_Throws(int from,int to)
        {
            //arange
            residence = new Residence()
            {
                AvailableFrom = DateTime.Today.AddDays(from),
                AvailableTo = DateTime.Today.AddDays(to)
            };

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => ResidenceService.UpdateResidenceAvailabilityAsync(residence));
        }
    }
}