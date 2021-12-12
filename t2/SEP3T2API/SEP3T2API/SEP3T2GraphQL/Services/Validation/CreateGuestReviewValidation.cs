using System;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateGuestReviewValidation
    {
        public void ValidateGuestReview(GuestReview guestReview)
        {
            ValidateRating(guestReview);
        }

        private static void ValidateRating(GuestReview guestReview)
        {
            if (guestReview.Rating is < 0 or > 5)
            {
                throw new ArgumentException("Invalid rating, must be between 0 and 5");
            }
        }
    }
}