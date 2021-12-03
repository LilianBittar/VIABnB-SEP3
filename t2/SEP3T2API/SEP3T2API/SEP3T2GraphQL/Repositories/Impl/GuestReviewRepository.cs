using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class GuestReviewRepository : IGuestReviewRepository
    {
        private string uri = "http://localhost:8080/guestreviews";
        private readonly HttpClient client;

        public GuestReviewRepository()
        {
            client = new HttpClient();
        }

        public Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}