using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public class GuestReviewService : IGuestReviewService
    {
        private readonly IGuestReviewRepository _guestReviewRepository;
        private readonly CreateGuestReviewValidation _createGuestReviewValidation;

        public GuestReviewService(IGuestReviewRepository guestReviewRepository,
            CreateGuestReviewValidation createGuestReviewValidation)
        {
            _guestReviewRepository = guestReviewRepository;
            _createGuestReviewValidation = createGuestReviewValidation;
        }

        public async Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview)
        {
            if (guestReview == null)
            {
                throw new ArgumentException("guestReview is required");
            }
            await _createGuestReviewValidation.ValidateGuestReview(guestReview);
            var guestReviews = await _guestReviewRepository.GetAllGuestReviewsByGuestIdAsync(guestReview.GuestId);

            // Updates review if host already have an HostReview for the guest. 
            if (guestReviews.Where(h => h.GuestId == guestReview.GuestId && h.HostId == guestReview.HostId).ToList()
                .Any())
            {
                var updatedReview = await UpdateGuestReviewAsync(guestReview);
                return updatedReview;
            }

            return await _guestReviewRepository.CreateGuestReviewAsync(guestReview);
        }

        public async Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview)
        {
            if (guestReview == null)
            {
                throw new ArgumentException("You are updating with null guest review");
            }

            return await _guestReviewRepository.UpdateGuestReviewAsync(guestReview);
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByHostIdAsync(int id)
        {
            return await _guestReviewRepository.GetAllGuestReviewsByHostIdAsync(id);
        }
    }
}