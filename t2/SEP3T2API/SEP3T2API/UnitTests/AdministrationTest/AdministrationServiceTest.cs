using System.Collections.Generic;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.AdministrationValidation;
using SEP3T2GraphQL.Services.Validation.AdministrationValidation.Impl;

namespace UnitTests.AdministrationTest
{
    [TestFixture]
    public class AdministrationServiceTest
    {
        private IAdminValidation _adminValidation;
        private IList<GuestRegistrationRequest> guestsRequests;
        private IList<HostRegistrationRequest> hostsRequests;
        private Host host;

        [SetUp]
        public void SetUp()
        {
            _adminValidation = new AdminValidationImpl();

            host = new Host()
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

            hostsRequests = new List<HostRegistrationRequest>();
            hostsRequests.Add(new HostRegistrationRequest()
            {
                Id = 1,
                CprNumber = "11111111111",
                PersonalImage = "image",
                Status = RequestStatus.NotAnswered
            });

            guestsRequests = new List<GuestRegistrationRequest>();
            guestsRequests.Add(new GuestRegistrationRequest()
            {
                Host = host,
                Id = 1,
                Status = RequestStatus.NotAnswered,
                StudentIdImage = "Image",
                StudentNumber = 111
            });
        }
    }
}