using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public class HostReviewServiceImpl : IHostReviewService
    {
        private readonly IHostReviewGuestRepository _hostReviewGuestRepository;
        private readonly CreateHostReviewValidation _createHostReviewValidation;

        public HostReviewServiceImpl(IHostReviewGuestRepository hostReviewGuestRepository,
            CreateHostReviewValidation createHostReviewValidation)
        {
            _hostReviewGuestRepository = hostReviewGuestRepository;
            _createHostReviewValidation = createHostReviewValidation;
        }
        
        public async Task<HostReview> CreateHostReviewAsync(HostReview hostReview)
        {
            if (hostReview == null)
            {
                throw new ArgumentException("hostReview is required");
            }
            _createHostReviewValidation.ValidateHostReview(hostReview);
            var hostReviews = await _hostReviewGuestRepository.GetAllHostReviewsByHostIdAsync(hostReview.hostId);
            
            // Updates review if host already have an HostReview for the guest. 
            if (hostReviews.Where(h => h.hostId == hostReview.hostId && h.GuestId == hostReview.GuestId).ToList().Any())
            {
                var updatedReview = await UpdateHostReviewAsync(hostReview);
                return updatedReview;
            }

            return await _hostReviewGuestRepository.CreateHostReviewAsync(hostReview);
        }

        public async Task<HostReview> UpdateHostReviewAsync(HostReview hostReview)
        {

            return await _hostReviewGuestRepository.UpdateHostReviewAsync(hostReview);

        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByGuestIdAsync(int id)
        {
            return await _hostReviewGuestRepository.GetAllHostReviewsByGuestIdAsync(id);
        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id)
        {
            return await _hostReviewGuestRepository.GetAllHostReviewsByHostIdAsync(id);
        }
    }
}