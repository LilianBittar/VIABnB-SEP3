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
        private readonly CreateGuestReviewValidation _createGuestReviewValidation;

        public HostReviewServiceImpl(IHostReviewGuestRepository hostReviewGuestRepository,
            CreateGuestReviewValidation createGuestReviewValidation)
        {
            _hostReviewGuestRepository = hostReviewGuestRepository;
            _createGuestReviewValidation = createGuestReviewValidation;
        }
        
        public async Task<HostReview> CreateHostReviewAsync(HostReview hostReview)
        {
            if (hostReview == null)
            {
                throw new ArgumentException("hostReview is required");
            }
            _createGuestReviewValidation.ValidateHostReview(hostReview);
            var hostReviews = await _hostReviewGuestRepository.GetAllHostReviewsByHostIdAsync(hostReview.hostId);
            
            // Updates review if host already have an HostReview for the guest. 
            if (hostReviews.Where(h => h.ViaId == hostReview.ViaId).ToList().Any())
            {
                var updatedReview = await _hostReviewGuestRepository.UpdateGuestReviewAsync(hostReview);
                return updatedReview;
            }

            return await _hostReviewGuestRepository.CreateGuestReviewAsync(hostReview);
        }

        public async Task<HostReview> UpdateHostReviewAsync(HostReview hostReview)
        {

            return await _hostReviewGuestRepository.UpdateGuestReviewAsync(hostReview);

        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id)
        {
            return await _hostReviewGuestRepository.GetAllHostReviewsByHostIdAsync(id);
        }
    }
}