using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Impl;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace UnitTests
{
    public class GetResidencesByHostTests
    {
        // Todo Do over, take repository out of the test + add [Test] + boundary test (+1, 0, -1)

        private IResidenceService _residenceReviewService;
        private IResidenceRepository residenceRepository;
        private IResidenceValidation _residenceValidation;
       
        
        [SetUp]
        public void Setup()
        {
            _residenceValidation = new ResidenceValidationImpl();
            residenceRepository = new ResidenceRepositoryImpl();
            _residenceReviewService = new ResidenceReviewServiceImpl(residenceRepository);
        }

        [Test]
        public void GetResidenceByHostSunnyScenario()
        {
            //arange
            int hostId = 1;
           
            
            //act and assert
            Assert.DoesNotThrowAsync(()=>_residenceReviewService.GetAllRegisteredResidencesByHostIdAsync(hostId));
        }
        
        [Test]
        public void GetOneResidenceByHost()
        {
            //arange
            int hostId = 1;
            //TODO need to add residence to list
            
            //
            Task<IList<Residence>> residences =  _residenceReviewService.GetAllRegisteredResidencesByHostIdAsync(1);

            //assert
            Assert.Equals(1,residences.Result.Count);
        }
        
        [Test]
        public void GetZeroResidencesByHost()
        {
            //arange
            int hostId = 1;
            //TODO need empty list
            
            //
            Task<IList<Residence>> residences = _residenceReviewService.GetAllRegisteredResidencesByHostIdAsync(1);

            //assert
            Assert.Equals(0,residences.Result.Count);
        }
        
        [Test]
        public void GetManyResidencesByHost()
        {
            //arange
            int hostId = 1;
            //TODO need to add a couple residences to list
            
            //
            Task<IList<Residence>> residences = _residenceReviewService.GetAllRegisteredResidencesByHostIdAsync(1);

            //assert
            Assert.Equals(0,residences.Result.Count);
        }
        
        
        
    }
}