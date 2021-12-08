using System;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateHostReviewValidation
    {
        private readonly IHostReviewGuestRepository _hostReviewGuestRepository;
        
        public CreateHostReviewValidation(IHostReviewGuestRepository hostReviewGuestRepository,
            IRentRequestRepository rentRequestRepository)
        {
            _hostReviewGuestRepository = hostReviewGuestRepository;
        }
        
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