using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;

namespace UnitTests.GuestReviewTest
{
    [TestFixture]
    public class GetGuestReview
    {
        private GuestReview _guestReview;
        private IGuestReviewService _guestReviewService;
        private Mock<IGuestReviewRepository> _guestReviewRepository;

        [SetUp]
        public void SetUp()
        {
            _guestReview = new GuestReview()
            {
                Rating = 3.3,
                Text = "Test",
                HostEmail = "Test@test.tt",
                CreatedDate = DateTime.Now
            };
            _guestReviewRepository = new Mock<IGuestReviewRepository>();
            _guestReviewService = new GuestReviewService(_guestReviewRepository.Object);
        }

        [Test]
        public void GetAllGuestReviewsDoesNotThrowExceptionsTest()
        {
            var list = new List<GuestReview>();
            list.Add(_guestReview);
            _guestReviewRepository.Setup(exp => exp.GetAllGuestReviewsByGuestIdAsync(1).Result)
                .Returns(list);
            Assert.DoesNotThrowAsync(async () => await _guestReviewService.GetAllGuestReviewsByGuestIdAsync(1));
        }
    }
}