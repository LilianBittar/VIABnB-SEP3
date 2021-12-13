using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IFacilityRepository
    {
        /// <summary>
        /// Crate a new Facility via API
        /// </summary>
        /// <param name="facility">The new Facility</param>
        /// <param name="residenceId">The Facility's Residence's id</param>
        /// <returns>Facility object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Facility> CreateResidenceFacilityAsync(Facility facility, int residenceId);
        /// <summary>
        /// Get a list of Guest objects via API
        /// </summary>
        /// <returns>List of Guest objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<Facility>> GetAllFacilitiesAsync();
        /// <summary>
        /// Get a Facility object based on the given parameter via API
        /// </summary>
        /// <param name="id">The Facility's id</param>
        /// <returns>Facility object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Facility> GetFacilityByIdAsync(int id);
        /// <summary>
        /// Delete a Facility object via API
        /// </summary>
        /// <param name="facility">The Facility to be deleted</param>
        /// <param name="residenceId">The Facility's Residence's id</param>
        /// <returns>Updated Facility object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Facility> DeleteResidenceFacilityAsync(Facility facility, int residenceId);
    }
}