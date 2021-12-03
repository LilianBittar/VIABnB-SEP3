using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task ValidateResidenceReview(Residence residence, ResidenceReview residenceReview)
        {
            await ValidateRentRequestExistAndIsApproved(residence, residenceReview); 
        }

        /// <summary>
        /// Validates if the guest have a rent request for the chosen residence and if the rent request has status of <c>APPROVED</c>. 
        /// </summary>
        /// <param name="residence">residence that the review is for</param>
        /// <param name="residenceReview">the review that is being validated</param>
        /// <exception cref="ArgumentException">if guest have never rented the residence before</exception>
        /// 
        private async Task ValidateRentRequestExistAndIsApproved(Residence residence, ResidenceReview residenceReview)
        {
            var rentRequests = (await _rentRequestRepository.GetRentRequestsByGuestId(residenceReview.GuestViaId))
                .Where(r => r.Residence.Id == residence.Id).ToList();
            if (rentRequests == null || !rentRequests.Any())
            {
                throw new ArgumentException("Guest have never rented the residence before"); 
            }

            if (!rentRequests.Where(r => r.Status == RentRequestStatus.APPROVED).ToList().Any())
            {
                throw new ArgumentException("Guest has never rented the residence before"); 
            }
        }
        
        
    }
}