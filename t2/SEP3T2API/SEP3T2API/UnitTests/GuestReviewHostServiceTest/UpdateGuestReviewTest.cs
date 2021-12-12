using System;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.GuestReviewHostServiceTest
{
    [TestFixture]
    public class UpdateGuestReviewTest
    {
        private Mock<IGuestReviewRepository> _guestReviewHostRepository;
        private CreateGuestReviewValidation _validator;
        private GuestReviewService _guestReviewService;
        
        [SetUp]
        public void SetUp()
        {
            _guestReviewHostRepository = new Mock<IGuestReviewRepository>();
            _validator = new CreateGuestReviewValidation();
            _guestReviewService = new GuestReviewService(_guestReviewHostRepository.Object, _validator);
        }

        [Test]
        public void UpdateGuestReviewThrowsArgumentExceptionTest()
        {
            GuestReview guestReview = null;
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _guestReviewService.UpdateGuestReviewAsync(guestReview));
        }
    }
}