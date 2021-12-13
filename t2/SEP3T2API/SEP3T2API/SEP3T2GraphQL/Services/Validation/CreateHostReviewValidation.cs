using System;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateHostReviewValidation
    {
        public void ValidateHostReview(HostReview hostReview)
        {
            ValidateRating(hostReview);
        }

        private void ValidateRating(HostReview hostReview)
        {
            if (hostReview.Rating is < 0 or > 5)
            {
                throw new ArgumentException("Invalid rating, must be between 0 and 5");
            }
        }
    }
}