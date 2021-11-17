using System;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.GuestRegistrationRequestValidation;
using SEP3T2GraphQL.Services.Validation.GuestRegistrationRequestValidation.Impl;

namespace UnitTests
{
    [TestFixture]
    public class GuestRegistrationRequestServiceTest
    {
        private IGuestRegistrationRequestValidation validation;
        private GuestRegistrationRequest request;
        private Host host;

        [SetUp]
        public void SetUp()
        {
            validation = new GuestRegistrationRequestValidationImpl();

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

            request = new GuestRegistrationRequest()
            {
                Id = 1,
                Host = host,
                Status = RequestStatus.NotAnswered,
                StudentIdImage = "Image",
                StudentNumber = 123456
            };
        }

        [Test]
        public void ChangeHostRequestStatusSunnyScenario()
        {
            Assert.DoesNotThrow(() => validation.IsValidRequest(request));
        }

        [TestCase(null)]
        public void ChangeHostRequestStatusWithNullRequestTest(GuestRegistrationRequest guestRegistrationRequest)
        {
            Assert.Throws<ArgumentException>(() => validation.IsValidRequest(guestRegistrationRequest));
        }

        [TestCase(2, "no", "img", 123456789)]
        [TestCase(2, RequestStatus.Approved,"img" , 0)]
        [TestCase(2, RequestStatus.Approved, "img" ,-1)]
        public void CreateHostRequestStatusWithInvalidRequestTest(int id, 
            RequestStatus status, string image, int sn)
        {
            Assert.Throws<ArgumentException>(() => validation.IsValidRequest(new GuestRegistrationRequest()
            {
                Id = id,
                Host = host,
                Status = status,
                StudentIdImage = image,
                StudentNumber = sn
            }));
        }
    }
}