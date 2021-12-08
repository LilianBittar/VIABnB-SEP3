using System;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateGuestReviewValidation
    {
        private readonly IGuestReviewHostRepository _guestReviewHostRepository;

        public CreateGuestReviewValidation(IGuestReviewHostRepository guestReviewHostRepository)
        {
            _guestReviewHostRepository = guestReviewHostRepository;
        }
        
        public void ValidateGuestReview(GuestReview guestReview)
        {
            ValidateRating(guestReview);
        }

        private void ValidateRating(GuestReview guestReview)
        {
            if (guestReview.Rating is < 0 or > 5)
            {
                throw new ArgumentException("Invalid rating, must be between 0 and 5");
            }
        }
    }
}