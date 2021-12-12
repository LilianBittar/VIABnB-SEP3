using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IRentRequestRepository
    {
        /// <summary>
        /// Create a new RentRequest object via API
        /// </summary>
        /// <param name = "request">The new RentRequest</param>
        /// <returns>RentRequest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<RentRequest> CreateRentRequestAsync(RentRequest request);
        /// <summary>
        /// Get a RentRequest object based on the given parameter via API
        /// </summary>
        /// <param name="id">The targeted RentRequest's id</param>
        /// <returns>A RentRequest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<RentRequest> GetRentRequestByIdAsync(int id);
        /// <summary>
        /// Get a list of RentRequest objects via API
        /// </summary>
        /// <returns>A list of RentRequest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<RentRequest>> GetAllRentRequestAsync();
        /// <summary>
        /// Update a RentRequest object via API
        /// </summary>
        /// <param name="request">The targeted RentRequest for update</param>
        /// <returns>The updated RentRequest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<RentRequest> UpdateRentRequestStatusAsync(RentRequest request);
        /// <summary>
        /// Get a list of RentRequest objects with status: NOTANSWERED via API
        /// </summary>
        /// <returns>a list of RentRequest objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<RentRequest>> GetAllNotAnsweredRentRequestAsync();
        /// <summary>
        /// Get a RentRequest object based on the given parameter via API
        /// </summary>
        /// <param name="guestId">The targeted RentRequest's Guest's id</param>
        /// <returns>A RentRequest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<RentRequest>> GetRentRequestsByGuestIdAsync(int guestId);
        /// <summary>
        /// Get a RentRequest object based on the given parameter via API
        /// </summary>
        /// <param name="viaId">The targeted RentRequest's Guest's ViaId</param>
        /// <returns>A RentRequest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<RentRequest>> GetRentRequestsByViaIdAsync(int viaId); 
    }
}