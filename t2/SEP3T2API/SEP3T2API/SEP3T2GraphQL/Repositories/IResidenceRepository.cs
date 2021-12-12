using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IResidenceRepository
    {
        /// <summary>
        /// Get a Residence object by the given parameter via API
        /// </summary>
        /// <param name="id">The targeted Residence's id</param>
        /// <returns>A Residence object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Residence> GetResidenceByIdAsync(int id);
        /// <summary>
        /// Create a new Residence object via API
        /// </summary>
        /// <param name="residence">The new Residence</param>
        /// <returns>A Residence object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Residence> CreateResidenceAsync(Residence residence);
        /// <summary>
        /// Update a Residence availability via API
        /// </summary>
        /// <param name="residence">The targeted Residence for update</param>
        /// <returns>An updated Residence object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence);
        /// <summary>
        /// Get a list of Residence objects by a given parameter via API
        /// </summary>
        /// <param name="id">The Host's id who own the Residences</param>
        /// <returns>A list of Residence objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id);
        /// <summary>
        /// Get a list of Residence objects via API
        /// </summary>
        /// <returns>A list of Residence objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IList<Residence>> GetAllResidenceAsync();
        /// <summary>
        /// Update a Residence object via API
        /// </summary>
        /// <param name="residence">The updated Residence</param>
        /// <returns>Updated Residence object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Residence> UpdateResidenceAsync(Residence residence);
        /// <summary>
        /// Delete a Residence object via API
        /// </summary>
        /// <param name="residence">The targeted Residence for deletion</param>
        /// <returns>The deleted Residence object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Residence> DeleteResidenceAsync(Residence residence);
    }
}