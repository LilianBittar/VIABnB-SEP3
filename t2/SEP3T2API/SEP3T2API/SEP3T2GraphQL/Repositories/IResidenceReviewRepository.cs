using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IResidenceReviewRepository
    {
        /// <summary>
        /// Create a new ResidenceReview object via API
        /// </summary>
        /// <param name="residence">The ResidenceReview's Residence</param>
        /// <param name="residenceReview">The new ResidenceReview object</param>
        /// <returns>The newly created ResidenceReview</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<ResidenceReview> CreateResidenceReviewAsync(Residence residence, ResidenceReview residenceReview);
        /// <summary>
        /// Get a list of ResidenceReviews based on the given parameter via API
        /// </summary>
        /// <param name="residenceId">The targeted ResidenceReview's Residence's id</param>
        /// <returns>A list of ResidenceReview objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<IEnumerable<ResidenceReview>> GetAllResidenceReviewByResidenceIdAsync(int residenceId);
        /// <summary>
        /// Update a ResidenceReview object via API
        /// </summary>
        /// <param name="residenceId">The ResidenceReview's Residence's id</param>
        /// <param name="updatedReview">The updated ResidenceReview object</param>
        /// <returns>The updated ResidenceReview object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<ResidenceReview> UpdateResidenceReviewAsync(int residenceId, ResidenceReview updatedReview); 

    }
}