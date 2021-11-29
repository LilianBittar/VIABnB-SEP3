using System;
using NUnit.Framework;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Impl;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation.GuestValidation;
using SEP3T2GraphQL.Services.Validation.GuestValidation.Impl;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;

namespace UnitTests
{
    public class GetGuestByStudentNumber
    {
        private IGuestService guestService;
        private IGuestRepository GuestRepository;
        private IGuestValidation GuestValidation;
        private IHostService HostService;
        private IHostRepository HostRepository;
        private IHostValidation HostValidation;

        [SetUp]

        public void SetUp()
        {
            GuestValidation = new GuestValidationImpl();
            GuestRepository = new GuestRepository();
            HostValidation = new HostValidationImpl();
            HostRepository = new HostRepositoryImpl(HostValidation);
            HostService = new HostServiceImpl(HostRepository);
            guestService = new GuestServiceImpl(GuestRepository, HostService);
        }
        
        [Test]
        
        public void GetGuestByStudentNumberSunnyScenario()
        {
            int studentNumber = 111111;
            
            Assert.DoesNotThrowAsync(()=>GuestRepository.GetGuestByStudentNumber(studentNumber));
           
        }
        
    }
    
}