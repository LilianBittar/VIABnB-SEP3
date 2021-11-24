
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Impl;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;

namespace UnitTests
{
    public class ValidateHostAsync
    {
        private IHostService HostService;
        private IHostRepository HostRepository;
        private IHostValidation HostValidation;
        private Host Host;
        
        [SetUp]
            public void SetUp()
            {
                HostValidation = new HostValidationImpl();
                HostRepository = new HostRepositoryImpl(HostValidation);
                HostService = new HostServiceImpl(HostRepository);
            }

            [Test]
            public void ValidateHostAsyncTest()
            {
                Host = new Host()
                {
                    Id = 1,
                    FirstName = "Hello",
                    LastName = "hello",
                    PhoneNumber = "123374",
                    Email = "Email@e.test",
                    Password = "pass",
                    HostReviews = null,
                    ProfileImageUrl = "image",
                    IsApprovedHost = false
                };
                
                Assert.DoesNotThrowAsync(()=>HostRepository.ValidateHostAsync(Host));
               // Assert.DoesNotThrowAsync(() => HostService.ValidateHostAsync(Host));
            }
            
    }
}