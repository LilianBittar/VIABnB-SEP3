using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IHostReviewGuestRepository
    {
        
        Task<HostReview> CreateGuestReviewAsync(HostReview hostReview);
        
        Task<HostReview> UpdateGuestReviewAsync(HostReview hostReview);
        
        Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id);
    }
}