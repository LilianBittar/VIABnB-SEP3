using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class ResidenceReviewService : IResidenceReviewService
    {
        private readonly IResidenceReviewRepository _residenceReviewRepository;
        private readonly CreateResidenceReviewValidator _validator;

        public ResidenceReviewService(IResidenceReviewRepository residenceReviewRepository,
            CreateResidenceReviewValidator validator)
        {
            _residenceReviewRepository = residenceReviewRepository;
            _validator = validator;
        }

        public async Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview)
        {
            if (residence == null || residenceReview == null)
            {
                throw new ArgumentException("residence and residenceReview is required");
            }

            await _validator.ValidateResidenceReview(residence, residenceReview);
            var residenceReviews = await _residenceReviewRepository.GetAllByResidenceIdAsync(residence.Id);
            // Updates review if guest already have an ResidenceReview for the residence. 
            if (residenceReviews.Where(r => r.GuestViaId == residenceReview.GuestViaId).ToList().Any())
            {
                var updatedReview = await _residenceReviewRepository.UpdateAsync(residence.Id, residenceReview);
                return updatedReview;
            }

            return await _residenceReviewRepository.CreateAsync(residence, residenceReview);
        }
        
    }
}