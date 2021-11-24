using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IRentRequestRepository
    {
        Task<RentRequest> CreateAsync(RentRequest request);
        Task<RentRequest> UpdateAsync(RentRequest request);
        Task<RentRequest> GetAsync(int id);
        Task<IEnumerable<RentRequest>> GetAllAsync(); 
    }
}