using System;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateGuestReviewValidation
    {
        private readonly IHostReviewGuestRepository _hostReviewGuestRepository;

        /// <summary>
        /// Checks if an <c>HostReview</c> is valid
        /// </summary>
        /// <remarks>
        /// This method will not return any booleans. Instead void will be returned if review is valid.
        /// If review is not valid, then an exception will be thrown. 
        /// </remarks>
        /// <param name="hostReview">the review that is being validated</param>
        /// <exception cref="ArgumentException">If rating is not between 0 and 5</exception>
        public CreateGuestReviewValidation(IHostReviewGuestRepository hostReviewGuestRepository,
            IRentRequestRepository rentRequestRepository)
        {
            _hostReviewGuestRepository = hostReviewGuestRepository;
        }
        
        /// <summary>
        /// Validates if the host review is correct
        /// </summary>
        /// <param name="hostReview">the review that is being validated</param>
        /// <exception cref="ArgumentException">If rating is not between 0 and 5</exception>
        public void ValidateHostReview(HostReview hostReview)
        {
            ValidateRating(hostReview);
        }
        
        /// <summary>
        /// Validates if an rating is between 0 or 5
        /// </summary>
        /// <param name="hostReview">review that is being validated</param>
        /// <exception cref="ArgumentException">If rating is not between 0 and 5</exception>
        private void ValidateRating(HostReview hostReview)
        {
            if (hostReview.Rating is < 0 or > 5)
            {
                throw new ArgumentException("Invalid rating, must be between 0 and 5");
            }
        }
    }
}