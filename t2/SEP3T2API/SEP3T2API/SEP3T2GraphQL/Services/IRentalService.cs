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
        /// <returns>the created RentRequest</returns>
        /// <exception cref="ArgumentException">Request is null</exception>
        /// <exception cref="ArgumentException">Number of guests is less than 1</exception>
        /// <exception cref="ArgumentException">Number of guests exceeds the max specified by host</exception>
        /// <exception cref="ArgumentException">if the start date and end date is the same</exception>
        /// <exception cref="ArgumentException">if end date is earlier than start date</exception>
        /// <exception cref="ArgumentException">if start date is earlier than today</exception>
        /// <exception cref="ArgumentException">if end date is earlier than today</exception>
        /// <exception cref="ArgumentException">if rent period of request is outside the available from and available to date of the residence</exception>
        /// <exception cref="ArgumentException">If residence is not available</exception>
        /// <exception cref="ArgumentException">If approved rent request exist for request's residence in same rent period as the request.</exception>
        Task<RentRequest> CreateRentRequest(RentRequest request);

        Task<RentRequest> ApproveRentRequestAsync(RentRequest request);
        Task<RentRequest> RejectRentRequestAsync(RentRequest request);
        Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync();
        Task<IEnumerable<RentRequest>> GetAllRentRequestByResidenceId(int residenceId);
        Task<RentRequest> GetRentRequestAsync(int id);
    }
}