using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IGuestReviewHostRepository
    {
        /// <summary>
        /// Method for creating the review for any guest 
        /// </summary>
        /// <param name="guestReview">The targeted GuestReview object to create</param>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>GuestReview object</returns>
        Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview);
        
        /// <summary>
        /// Method for updating the review for any guest 
        /// </summary>
        /// <param name="guestReview">The targeted GuestReview object to update</param>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>GuestReview object</returns>
        Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview);
        
        /// <summary>
        /// Method for getting all guest review  the review for any guest by host id
        /// </summary>
        /// <param name="id">The targeted id of the host that we need to get all the guests review from </param>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>the list with all the guestReview object</returns>
        Task<IEnumerable<GuestReview>> GetAllGuestReviewsByHostIdAsync(int id);
        
        /// <summary>
        /// Method for getting all guest review  the review for any guest by guest id
        /// </summary>
        /// <param name="id">The targeted id of the guest that we need to get all the guests review from </param>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>the list with all the guestReview object</returns>
        Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id);
    }
}