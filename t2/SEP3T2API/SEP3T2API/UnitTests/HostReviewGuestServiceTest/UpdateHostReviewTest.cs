using System;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests.HostReviewGuestServiceTest
{
    [TestFixture]
    
    public class UpdateHostReviewTest
    {
        
        private Mock<IRentalService> _rentalService;
        private Mock<IHostReviewRepository> _hostReviewRepository;
        private CreateHostReviewValidation _validation;
        private IHostReviewService _hostReviewService;

        [SetUp]

        public void SetUp()
        {
            _rentalService = new Mock<IRentalService>();
            _hostReviewRepository = new Mock<IHostReviewRepository>();
            _validation = new CreateHostReviewValidation(_rentalService.Object);
            _hostReviewService = new HostReviewService(_hostReviewRepository.Object, _validation);
        }
        
        [Test]
        public void UpdateHostReviewThrowsArgumentExceptionTest()
        {
            HostReview hostReview = null;
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _hostReviewService.UpdateHostReviewAsync(hostReview));
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(100)]
        public void UpdateHostReview_InvalidRating_ThrowsArgumentException(int rating)
        {
            HostReview hostReview = new HostReview()
            {
                CreatedDate = new DateTime(),
                GuestId = 1,
                hostId = 3,
                Rating = rating,
                Text = "Was oki doki."
            };
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _hostReviewService.UpdateHostReviewAsync(hostReview));
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        public void UpdateHostReview_ValidRating_DoesNotThrow(int rating)
        {
            HostReview hostReview = new HostReview()
            {
                CreatedDate = new DateTime(),
                GuestId = 1,
                hostId = 3,
                Rating = rating,
                Text = "Was oki doki."
            };
            Assert.DoesNotThrowAsync(async () =>
                await _hostReviewService.UpdateHostReviewAsync(hostReview));
        }
    }
}