using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IHostReviewGuestRepository
    {
        Task<HostReview> CreateHostReviewAsync(HostReview hostReview);
        Task<HostReview> UpdateHostReviewAsync(HostReview hostReview);
        Task<IEnumerable<HostReview>> GetAllHostReviewsByGuestIdAsync(int id);
    }
}