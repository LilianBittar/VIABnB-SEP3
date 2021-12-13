using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public class HostReviewService : IHostReviewService
    {
        private readonly IHostReviewRepository _hostReviewRepository;
        private readonly CreateHostReviewValidation _createHostReviewValidation;

        public HostReviewService(IHostReviewRepository hostReviewRepository,
            CreateHostReviewValidation createHostReviewValidation)
        {
            _hostReviewRepository = hostReviewRepository;
            _createHostReviewValidation = createHostReviewValidation;
        }
        
        public async Task<HostReview> CreateHostReviewAsync(HostReview hostReview)
        {
            if (hostReview == null)
            {
                throw new ArgumentException("hostReview is required");
            }
            _createHostReviewValidation.ValidateHostReview(hostReview);
            var hostReviews = await _hostReviewRepository.GetAllHostReviewsByHostIdAsync(hostReview.hostId);
            
            // Updates review if host already have an HostReview for the guest. 
            if (hostReviews.Where(h => h.hostId == hostReview.hostId && h.GuestId == hostReview.GuestId).ToList().Any())
            {
                var updatedReview = await UpdateHostReviewAsync(hostReview);
                return updatedReview;
            }

            return await _hostReviewRepository.CreateHostReviewAsync(hostReview);
        }

        public async Task<HostReview> UpdateHostReviewAsync(HostReview hostReview)
        {

            return await _hostReviewRepository.UpdateHostReviewAsync(hostReview);

        }
        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id)
        {
            return await _hostReviewRepository.GetAllHostReviewsByHostIdAsync(id);
        }
    }
}