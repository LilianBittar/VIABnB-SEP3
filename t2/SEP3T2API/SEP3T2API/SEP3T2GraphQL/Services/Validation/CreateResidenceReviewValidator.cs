using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateResidenceReviewValidator
    {
        private readonly IResidenceReviewRepository _residenceReviewRepository;
        private readonly IRentRequestRepository _rentRequestRepository;

        public CreateResidenceReviewValidator(IResidenceReviewRepository residenceReviewRepository,
            IRentRequestRepository rentRequestRepository)
        {
            _residenceReviewRepository = residenceReviewRepository;
            _rentRequestRepository = rentRequestRepository;
        }

        /// <summary>
        /// Checks if an <c>ResidenceReview</c> is valod
        /// </summary>
        /// <remarks>
        /// This method will not return any booleans. Instead void will be returned if review is valid.
        /// If review is not valid, then an exception will be thrown. 
        /// </remarks>
        /// <param name="residence">residence that the review is intended for</param>
        /// <param name="residenceReview">the review that is being validated</param>
        /// <exception cref="ArgumentException">if guest have never rented the residence before</exception>
        /// <exception cref="ArgumentException">If rating is not between 0 and 5</exception>
        public async Task ValidateResidenceReview(Residence residence, ResidenceReview residenceReview)
        {
            await ValidateGuestHasRentedResidence(residence, residenceReview);
            ValidateRating(residenceReview);
        }

        /// <summary>
        /// Validates if the guest have a rent request for the chosen residence and if the rent request has status of <c>APPROVED</c>. 
        /// </summary>
        /// <param name="residence">residence that the review is for</param>
        /// <param name="residenceReview">the review that is being validated</param>
        /// <exception cref="ArgumentException">if guest have never rented the residence before</exception>
        /// 
        private async Task ValidateGuestHasRentedResidence(Residence residence, ResidenceReview residenceReview)
        {
            var rentRequests =
                (await _rentRequestRepository.GetRentRequestsByViaId(residenceReview.GuestViaId)).Where(r =>
                    r.Residence.Id == residence.Id);
            if (rentRequests == null || !rentRequests.Any())
            {
                throw new ArgumentException("Guest have never rented the residence before");
            }

            if (!rentRequests.Where(r => r.Status == RentRequestStatus.APPROVED).ToList().Any())
            {
                throw new ArgumentException("Guest has never rented the residence before");
            }
        }

        /// <summary>
        /// Validates if an rating is between 0 or 5
        /// </summary>
        /// <param name="residenceReview">review that is being validated</param>
        /// <exception cref="ArgumentException">If rating is not between 0 and 5</exception>
        private void ValidateRating(ResidenceReview residenceReview)
        {
            if (residenceReview.Rating is < 0 or > 5)
            {
                throw new ArgumentException("Invalid rating, must be between 0 and 5");
            }
        }
    }
}