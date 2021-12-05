using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public class GuestReviewService : IGuestReviewService
    {
        private IGuestReviewRepository _guestReviewRepository;

        public GuestReviewService(IGuestReviewRepository guestReviewRepository)
        {
            _guestReviewRepository = guestReviewRepository;
        }

        public Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id)
        {
            return await _guestReviewRepository.GetAllGuestReviewsByGuestIdAsync(id);
        }
    }
}