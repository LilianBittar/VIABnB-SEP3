using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IResidenceService
    {
        Task<Residence> GetResidenceAsync(int id);
        Task<Residence> CreateResidenceAsync(Residence residence);
        /// <summary>
        /// updates availability period of the residence and sests availability to true
        /// </summary>
        /// <param name="residence"></param>
        /// <returns> the updated Residence</returns>
        Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence);
        /// <summary>
        /// Gets all created residences by a host
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>list of residences</returns>
        Task<IList<Residence>> GetResidencesByHostIdAsync(int Id);
        /// <summary>
        /// gets all residences in the system that are available for rent
        /// </summary>
        /// <returns>list of available residences</returns>
        Task<IList<Residence>> GetAllAvailableResidencesAsync(); 
    }
}