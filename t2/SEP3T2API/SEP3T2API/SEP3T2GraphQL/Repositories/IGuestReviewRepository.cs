using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IGuestReviewRepository
    {
        /// <summary>
        /// Create a new GuestReview object via API
        /// </summary>
        /// <param name="guestReview">The new GuestReview</param>
        /// <returns>GuestReview object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview);
        
        /// <summary>
        /// Update a GuestReview object via API
        /// </summary>
        /// <param name="guestReview">The updated GuestReview</param>
        /// <returns>GuestReview object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview);
        
        /// <summary>
        /// Get a GuestReview objects based on the given parameter via API
        /// </summary>
        /// <param name="id">The Host's id who created the GuestReview</param>
        /// <returns>List og GuestREview</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<GuestReview>> GetAllGuestReviewsByHostIdAsync(int id);
        
        /// <summary>
        /// Get a list of GuestReview objects based on the given parameter via API
        /// </summary>
        /// <param name="id">The Guest's id who the GuestReview belongs to</param>
        /// <returns>List of GuestReview objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id);
    }
}