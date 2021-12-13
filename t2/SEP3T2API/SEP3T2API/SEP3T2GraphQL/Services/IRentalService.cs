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
        Task<RentRequest> CreateRentRequestAsync(RentRequest request);

        /// <summary>
        /// Get a list of RentRequest objects via repository
        /// </summary>
        /// <param name="hostId"></param>
        /// <returns>A list of RentRequest object</returns>
        /// <exception cref="System.ArgumentException">If the returned RentRequest is null</exception>
        Task<IEnumerable<RentRequest>> GetAllRentRequestsByHostIdAsync(int hostId);
        /// <summary>
        /// Get a list of RentRequest objects via repository
        /// </summary>
        /// <returns>A list of RentRequest object</returns>
        /// <exception cref="System.ArgumentException">If the returned RentRequest is null</exception>
        Task<RentRequest> GetRentRequestAsync(int id);
        /// <summary>
        /// Update a RentRequest object via repository
        /// </summary>
        /// <param name="request">The targeted RentRequest for update</param>
        /// <returns>The updated RentRequest object</returns>
        /// <exception cref="System.ArgumentException">If the RentRequest is null</exception>
        /// <exception cref="ArgumentException">Number of guests is less than 1</exception>
        /// <exception cref="ArgumentException">Number of guests exceeds the max specified by host</exception>
        /// <exception cref="ArgumentException">if the start date and end date is the same</exception>
        /// <exception cref="ArgumentException">if end date is earlier than start date</exception>
        /// <exception cref="ArgumentException">if start date is earlier than today</exception>
        /// <exception cref="ArgumentException">if end date is earlier than today</exception>
        /// <exception cref="ArgumentException">if rent period of request is outside the available from and available to date of the residence</exception>
        /// <exception cref="ArgumentException">If residence is not available</exception>
        /// <exception cref="ArgumentException">If approved rent request exist for request's residence in same rent period as the request.</exception>

        Task<RentRequest> UpdateRentRequestStatusAsync(RentRequest request);

        /// <summary>
        /// Get a list of RentRequest objects with status: NOTANSWERED via repository
        /// </summary>
        /// <param name="hostId"></param>
        /// <returns>a list of RentRequest objects</returns>
        /// <exception cref="System.ArgumentException">If the returned RentRequest is null</exception>
        Task<IEnumerable<RentRequest>> GetAllNotAnsweredRentRequestAsync(int hostId);
        /// <summary>
        /// Get a RentRequest object based on the given parameter via repository
        /// </summary>
        /// <param name="guestId">The targeted RentRequest's Guest's id</param>
        /// <returns>A RentRequest object</returns>
        /// <exception cref="System.ArgumentException">If the returned RentRequest is null</exception>
        Task<IEnumerable<RentRequest>> GetRentRequestsByGuestIdAsync(int guestId);
    }
}