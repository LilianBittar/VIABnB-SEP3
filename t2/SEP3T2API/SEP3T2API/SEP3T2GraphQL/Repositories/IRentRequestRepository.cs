using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IRentRequestRepository
    {
        /// <summary>
        /// Method that returns a newly created Rent Request based on the given parameter
        /// </summary>
        /// <param name = "request">The Rent Request form of that should be created in the system</param>
        /// <returns>RentRequest form </returns>
        Task<RentRequest> CreateAsync(RentRequest request);
        //TODO Check if we are using UpdateAsync in the system
        Task<RentRequest> UpdateAsync(RentRequest request);
        Task<RentRequest> GetAsync(int id);
        Task<IEnumerable<RentRequest>> GetAllAsync();

        Task<RentRequest> UpdateRentRequestStatusAsync(RentRequest request);
        Task<IEnumerable<RentRequest>> GetAllNotAnsweredRentRequestAsync();
        Task<IEnumerable<RentRequest>> GetRentRequestsByGuestId(int guestId); 
    }
}