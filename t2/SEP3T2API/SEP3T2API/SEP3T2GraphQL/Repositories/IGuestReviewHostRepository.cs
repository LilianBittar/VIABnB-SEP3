using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IGuestReviewHostRepository
    {
        Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview);
        
        Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview);
        
        Task<IEnumerable<GuestReview>> GetAllGuestReviewsByHostIdAsync(int id);
    }
}