using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IResidenceService
    {
        /// <summary>
        /// Get a Residence object by the given parameter via Repository
        /// </summary>
        /// <param name="id">The targeted Residence's id</param>
        /// <returns>A Residence object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Residence> GetResidenceByIdAsync(int id);
        /// <summary>
        /// Create a new Residence object via Repository
        /// </summary>
        /// <param name="residence">The new Residence</param>
        /// <returns>A Residence object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Residence> CreateResidenceAsync(Residence residence);

        /// <summary>
        /// Get a list of Residence objects by a given parameter via Repository
        /// </summary>
        /// <param name="id">The Host's id who own the Residences</param>
        /// <returns>A list of Residence objects</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IList<Residence>> GetResidencesByHostIdAsync(int id);
        /// <summary>
        /// Get a list of Residence objects via Repository
        /// </summary>
        /// <returns>A list of Residence objects</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IList<Residence>> GetAllAvailableResidencesAsync();
        /// <summary>
        /// Update a Residence object via Repository
        /// </summary>
        /// <param name="residence">The updated Residence</param>
        /// <returns>Updated Residence object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Residence> UpdateResidenceAsync(Residence residence);
        /// <summary>
        /// Delete a Residence object via Repository
        /// </summary>
        /// <param name="residence">The targeted Residence for deletion</param>
        /// <returns>The deleted Residence object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Residence> DeleteResidenceAsync(Residence residence);
    }
}