using NUnit.Framework;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Impl;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;

namespace UnitTests
{
    public class GetHostById
    {
        private IHostService HostService;
        private IHostRepository HostRepository;
        private IHostValidation HostValidation;

        [SetUp]

        public void SetUp()
        {
            HostValidation = new HostValidationImpl();
            HostRepository = new HostRepositoryImpl();
            HostService = new HostServiceImpl(HostRepository);
        }
        
        [Test]
        
        public void GetHostByIdSunnyScenario()
        {
            int hostId = 1;
            
            Assert.DoesNotThrowAsync(()=>HostRepository.GetHostById(hostId));
            Assert.DoesNotThrowAsync(() => HostService.GetHostById(hostId));
        }
    }
}