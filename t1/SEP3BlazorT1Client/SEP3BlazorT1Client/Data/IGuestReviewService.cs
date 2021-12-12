using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IGuestReviewService
    {
        /// <summary>
        /// Create a new GuestReview object via repository
        /// </summary>
        /// <param name="guestReview">The new GuestReview</param>
        /// <returns>GuestReview object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview);
        /// <summary>
        /// Get a GuestReview objects based on the given parameter via repository
        /// </summary>
        /// <param name="id">The Host's id who created the GuestReview</param>
        /// <returns>List og GuestReview</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>

        Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id);
    }
}