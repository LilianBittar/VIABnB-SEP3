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
    public class CreateGuestReviewTest
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
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(100)]
        public void CreateGuestReview_InvalidRating_ThrowsArgumentException(int rating)
        {
            GuestReview guestReview = new GuestReview()
            {
                CreatedDate = new DateTime(),
                GuestId = 1,
                HostId = 3,
                Rating = rating,
                Text = "Was oki doki."
            };
            Assert.ThrowsAsync<ArgumentException>(async () => 
                await _guestReviewService.CreateGuestReviewAsync(guestReview));
        }
        
        
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        public void CreateGuestReview_ValidRating_DoesNotThrow(int rating)
        {
            GuestReview guestReview = new GuestReview()
            {
                CreatedDate = new DateTime(),
                GuestId = 1,
                HostId = 3,
                Rating = rating,
                Text = "Was oki doki."
            };
            Assert.DoesNotThrowAsync(async () => 
                await _guestReviewService.CreateGuestReviewAsync(guestReview));
        }
    }
}