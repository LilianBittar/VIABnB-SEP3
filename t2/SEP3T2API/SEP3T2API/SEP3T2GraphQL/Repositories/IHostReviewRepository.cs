using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IHostReviewRepository
    {
        /// <summary>
        /// Create a new HostReview object via API
        /// </summary>
        /// <param name="hostReview">The new HostReview</param>
        /// <returns>The newly created H ostReview object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<HostReview> CreateHostReviewAsync(HostReview hostReview);
        /// <summary>
        /// Update a HostReview object via API
        /// </summary>
        /// <param name="hostReview">The updated HostReview</param>
        /// <returns>A HostReview object</returns>
        /// <exception cref="System.Exception"></exception>
        Task<HostReview> UpdateHostReviewAsync(HostReview hostReview);
        /// <summary>
        /// Get a list of HostReview objects based on the given parameter via API
        /// </summary>
        /// <param name="id">The targeted HostReview's Host's id</param>
        /// <returns>A list of HostReview objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id);
    }
}