using System;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests
{
    [TestFixture]
    public class ResidenceReadyForRentTest
    {
        private Residence residence = new Residence();
        private IResidenceService ResidenceService;
        private Mock<IResidenceRepository> ResidenceRepository;

        
        
        [SetUp]
        public void SetUp()
        {
            ResidenceRepository = new Mock<IResidenceRepository>();
            ResidenceService = new ResidenceServiceImpl(ResidenceRepository.Object, new CreateCityValidator());
        }
        
        [Test]
        public void UpdateResidenceAvailabilityAsync_ExpectedValues_DoesNotThrow()
        {
            //arange
            residence = new Residence()
            {
               AvailableFrom = DateTime.Today,
               AvailableTo = DateTime.Today
            };

            //act and assert
            Assert.DoesNotThrowAsync(() => ResidenceService.UpdateResidenceAvailabilityAsync(residence));
        }
    }
}