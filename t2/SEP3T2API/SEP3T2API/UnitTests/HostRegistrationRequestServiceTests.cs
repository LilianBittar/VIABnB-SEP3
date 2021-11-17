using System;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.HostRegistrationRequestValidation;
using SEP3T2GraphQL.Services.Validation.HostRegistrationRequestValidation.Impl;

namespace UnitTests
{
    [TestFixture]
    public class HostRegistrationRequestServiceTests
    {
        private IHostRegistrationRequestValidation validation;
        private HostRegistrationRequest request;
        private Host host;

        [SetUp]
        public void SetUp()
        {
            validation = new HostRegistrationRequestValidationImpl();

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

            request = new HostRegistrationRequest()
            {
                Id = 1,
                CprNumber = "1111111111",
                PersonalImage = "image",
                Status = RequestStatus.NotAnswered
            };
        }

        [Test]
        public void ChangeHostRequestStatusSunnyScenario()
        {
            Assert.DoesNotThrow(() => validation.IsValidRequest(request));
        }

        [TestCase(null)]
        public void ChangeHostRequestStatusWithNullRequestTest(HostRegistrationRequest hostRegistrationRequest)
        {
            Assert.Throws<ArgumentException>(() => validation.IsValidRequest(hostRegistrationRequest));
        }

        [TestCase(2, "1111111112", "i", RequestStatus.Approved)]
        [TestCase(2, "111111111", "i", RequestStatus.Approved)]
        [TestCase(2, "1111111112", "i", "no")]
        public void CreateHostRequestStatusWithInvalidRequestTest(int id, string cpr, string image,
            RequestStatus status)
        {
            Assert.Throws<ArgumentException>(() => validation.IsValidRequest(new HostRegistrationRequest()
            {
                Id = id,
                CprNumber = cpr,
                PersonalImage = image,
                Status = status
            }));
        }
    }
}