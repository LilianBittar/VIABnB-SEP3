using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IFacilityService
    {
        /// <summary>
        /// create a new facility and stores it in the system
        /// </summary>
        /// <param name="facility"></param>
        /// <returns> the created facility</returns>
        Task<Facility> CreateFacility(Facility facility);
        
        /// <summary>
        /// a method to get all the facilities stored in the system
        /// </summary>
        /// <returns> a list with all the facilites</returns>
        Task<IEnumerable<Facility>> GetAllFacilities();
        
        /// <summary>
        /// method to get the facility using an id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> the facility that matches the parameter id</returns>
        Task<Facility> GetFacilityById(int id);
    }
}