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
        private GuestReview _guestReview;
        private Mock<IGuestReviewRepository> _guestReviewHostRepository;
        private CreateGuestReviewValidation _validator;
        private GuestReviewService _guestReviewService;
        
        [SetUp]
        public void SetUp()
        {
            _guestReview = new GuestReview()
            {
                CreatedDate = new DateTime(),
                GuestId = 1,
                HostId = 3,
                Rating = 4.0,
                Text = "Was oki doki."
            };
    
            _guestReviewHostRepository = new Mock<IGuestReviewRepository>();
            _validator = new CreateGuestReviewValidation(_guestReviewHostRepository.Object);
            _guestReviewService = new GuestReviewService(_guestReviewHostRepository.Object, _validator);
        }

        [Test]
        public void UpdateGuestReviewThrowsArgumentExceptionTest()
        {
            GuestReview guestReview = null;
            Assert.ThrowsAsync<Exception>(async () =>
                await _guestReviewService.UpdateGuestReviewAsync(guestReview));
        }
    }
}