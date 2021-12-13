using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
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
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<RentRequest> CreateRentRequestAsync(RentRequest request);
        /// <summary>
        /// Update a RentRequest object via repository
        /// </summary>
        /// <param name="request">The targeted RentRequest for update</param>
        /// <returns>The updated RentRequest object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<RentRequest> UpdateRentRequestAsync(RentRequest request);

        /// <summary>
        /// Get a list of RentRequest objects with status: NOTANSWERED via repository
        /// </summary>
        /// <param name="hostId"></param>
        /// <returns>a list of RentRequest objects</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IEnumerable<RentRequest>> GetAllRentRequestsByHostIdAsync(int hostId);

        /// <summary>
        /// Get a list of RentRequest objects via repository
        /// </summary>
        /// <param name="hostId"></param>
        /// <returns>a list of RentRequest objects</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IEnumerable<RentRequest>> GetAllNotAnsweredRentRequestAsync(int hostId);
        /// <summary>
        /// Get a RentRequest object based on the given parameter via repository
        /// </summary>
        /// <param name="guestId">The targeted RentRequest's Guest's id</param>
        /// <returns>A RentRequest object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IEnumerable<RentRequest>> GetRentRequestsByGuestIdAsync(int guestId); 
    }
}