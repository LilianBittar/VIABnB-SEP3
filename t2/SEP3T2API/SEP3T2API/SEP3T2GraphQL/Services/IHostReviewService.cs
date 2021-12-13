using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IHostReviewService
    {
        /// <summary>
        /// Create a new HostReview object if any is not found, if any is found update the HostReview via repository
        /// </summary>
        /// <param name="hostReview">The new HostReview</param>
        /// <returns>The newly created H ostReview object</returns>
        /// <exception cref="System.ArgumentException">If the HostReview is null</exception>
        /// <exception cref="System.ArgumentException">If the HostReview's rating is not between 0 and 5</exception>
        Task<HostReview> CreateHostReviewAsync(HostReview hostReview);
        
        /// <summary>
        /// Update a HostReview object via repository
        /// </summary>
        /// <param name="hostReview">The updated HostReview</param>
        /// <returns>A HostReview object</returns>
        Task<HostReview> UpdateHostReviewAsync(HostReview hostReview);
        /// <summary>
        /// Get a list of HostReview objects based on the given parameter via repository
        /// </summary>
        /// <param name="id">The targeted HostReview's Host's id</param>
        /// <returns>A list of HostReview objects</returns>
        Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id);
    
    }
}