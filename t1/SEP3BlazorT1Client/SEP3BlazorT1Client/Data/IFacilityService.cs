using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IFacilityService
    {
        /// <summary>
        /// Crate a new Facility via repository
        /// </summary>
        /// <param name="facility">The new Facility</param>
        /// <param name="residenceId">The Facility's Residence's id</param>
        /// <returns>Facility object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Facility> CreateResidenceFacilityAsync(Facility facility, int residenceId);
        /// <summary>
        /// Get a list of Guest objects via repository
        /// </summary>
        /// <returns>List of Guest objects</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IEnumerable<Facility>> GetAllFacilitiesAsync();
        /// <summary>
        /// Delete a Facility object via repository
        /// </summary>
        /// <param name="facility">The Facility to be deleted</param>
        /// <param name="residenceId">The Facility's Residence's id</param>
        /// <returns>Updated Facility object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Facility> DeleteResidenceFacilityAsync(Facility facility, int residenceId);
    }
}