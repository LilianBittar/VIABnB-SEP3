using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IGuestReviewService
    {
        /// <summary>
        /// Create a new GuestReview object via repository
        /// </summary>
        /// <param name="guestReview">The new GuestReview</param>
        /// <returns>GuestReview object</returns>
        /// <exception cref="System.ArgumentException">If the GuestReview is null</exception>
        /// <exception cref="System.ArgumentException">If the GuestReview's rating is not between 0 and 5</exception>
        Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview);
        /// <summary>
        /// Update a GuestReview object via repository
        /// </summary>
        /// <param name="guestReview">The updated GuestReview</param>
        /// <returns>GuestReview object</returns>
        /// <exception cref="System.ArgumentException">If the GuestReview is null</exception>
        Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview);
        /// <summary>
        /// Get a GuestReview objects based on the given parameter via repository
        /// </summary>
        /// <param name="id">The Host's id who created the GuestReview</param>
        /// <returns>List og GuestREview</returns>
        Task<IEnumerable<GuestReview>> GetAllGuestReviewsByHostIdAsync(int id);
    }
}