using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IRentalService
    {
        /// <summary>
        /// Creates a new RentRequest for a Residence in the system, which
        /// the host of the residence can choose to reject or approve the request.
        /// </summary>
        /// <remarks>
        /// An request can either have status of: NotAnswered, NotApproved, Approved. 
        /// </remarks>
        /// <param name="request">the request which contains the residence that the guest wishes to rent
        /// and the guest, who wishes to rent a residence. </param>
        /// <returns></returns>
        Task<RentRequest> CreateRentRequest(RentRequest request);

        Task<RentRequest> ApproveRentRequestAsync(RentRequest request);
        Task<RentRequest> RejectRentRequestAsync(RentRequest request);
        Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync();
        Task<RentRequest> GetRentRequestAsync(int id);
    }
}