using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IFacilityService
    {
        /// <summary>
        /// Crate a new Facility via repository
        /// </summary>
        /// <param name="facility">The new Facility</param>
        /// <param name="residenceId">The Facility's Residence's id</param>
        /// <returns>Facility object</returns>
        /// <exception cref="System.Exception">If the returned Facility is null</exception>
        Task<Facility> CreateResidenceFacilityAsync(Facility facility, int residenceId);
        /// <summary>
        /// Get a list of Guest objects via repository
        /// </summary>
        /// <returns>List of Guest objects</returns>
        /// <exception cref="System.Exception">If the returned Facility is null</exception>
        Task<IEnumerable<Facility>> GetAllFacilitiesAsync();
        /// <summary>
        /// Get a Facility object based on the given parameter via repository
        /// </summary>
        /// <param name="id">The Facility's id</param>
        /// <returns>Facility object</returns>
        /// <exception cref="System.Exception">If the returned Facility is null</exception>
        Task<Facility> GetFacilityByIdAsync(int id);
        /// <summary>
        /// Delete a Facility object via repository
        /// </summary>
        /// <param name="facility">The Facility to be deleted</param>
        /// <param name="residenceId">The Facility's Residence's id</param>
        /// <returns>Updated Facility object</returns>
        /// <exception cref="System.Exception">If the API cant execute the method</exception>
        Task<Facility> DeleteResidenceFacilityAsync(Facility facility, int residenceId);
    }
}