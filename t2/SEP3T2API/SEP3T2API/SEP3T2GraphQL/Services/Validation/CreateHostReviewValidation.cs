using System;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateHostReviewValidation
    {
        private readonly IRentalService _rentalService;

        public CreateHostReviewValidation(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        /// <summary>
        /// Validates if the guest doing the review has ever rented a residence of the host under review
        /// </summary>
        /// <remarks>Method will return void if valid, else an exception will be thrown</remarks>
        /// <param name="hostReview">review being validated</param>
        /// <exception cref="ArgumentException">If guest has no approved <c>RentRequest</c> for a residence owned by host of the <c>GuestReview</c></exception>
        /// <exception cref="ArgumentException">If rating is not between 0 or 5</exception>
        public void ValidateHostReview(HostReview hostReview)
        {
            ValidateRating(hostReview);
        }

        /// <summary>
        /// Validates if the <c>Rating</c> of <c>hostReview</c> is between 0 or 5
        /// </summary>
        /// <param name="hostReview">review being validated</param>
        /// <exception cref="ArgumentException">if rating is not between 0 or 5</exception>
        private void ValidateRating(HostReview hostReview)
        {
            if (hostReview.Rating is < 0 or > 5)
            {
                throw new ArgumentException("Invalid rating, must be between 0 and 5");
            }
        }
    }
}