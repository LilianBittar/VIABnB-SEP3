using System.Collections.Generic;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace UnitTests
{
    public class GetResidencesByHostTests
    {
        // Todo Do over, take repository out of the test + add [Test] + boundary test (+1, 0, -1)

        private IResidenceService residenceService;
        private IResidenceRepository residenceRepository;
        private IResidenceValidation _residenceValidation;
       
        
        [SetUp]
        public void Setup()
        {
            _residenceValidation = new ResidenceValidationImpl();
            residenceRepository = new ResidenceRepositoryImpl(_residenceValidation);
            residenceService = new ResidenceServiceImpl(residenceRepository);
        }

        [Test]
        public void GetResidenceByHostSunnyScenario()
        {
            //arange
            int hostId = 1;
           
            
            //act and assert
            Assert.DoesNotThrowAsync(()=> residenceRepository.GetAllRegisteredResidencesByHostIdAsync(hostId));
            Assert.DoesNotThrowAsync(()=>residenceService.GetAllRegisteredResidencesByHostIdAsync(hostId));
        }
        
        public void GetOneResidenceByHost()
        {
            //arange
            int hostId = 1;
            //TODO need to add residence to list
            
            //
            IList<Residence> residences = (IList<Residence>) residenceService.GetAllRegisteredResidencesByHostIdAsync(1);

            //assert
            Assert.Equals(1,residences.Count);
        }
        
        public void GetZeroResidencesByHost()
        {
            //arange
            int hostId = 1;
            //TODO need empty list
            
            //
            IList<Residence> residences = (IList<Residence>) residenceService.GetAllRegisteredResidencesByHostIdAsync(1);

            //assert
            Assert.Equals(0,residences.Count);
        }
        
        public void GetManyResidencesByHost()
        {
            //arange
            int hostId = 1;
            //TODO need to add a couple residences to list
            
            //
            IList<Residence> residences = (IList<Residence>) residenceService.GetAllRegisteredResidencesByHostIdAsync(1);

            //assert
            Assert.Equals(0,residences.Count);
        }
        
        
        
    }
}