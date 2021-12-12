using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IHostReviewRepository
    {
        Task<HostReview> CreateHostReviewAsync(HostReview hostReview);
        Task<HostReview> UpdateHostReviewAsync(HostReview hostReview);
        Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id);
    }
}