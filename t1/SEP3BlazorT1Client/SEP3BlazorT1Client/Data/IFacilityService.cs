using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IFacilityService
    {
        Task<Facility> CreateFacility(Facility facility);
        Task<IEnumerable<Facility>> GetAllFacilities();
        Task<Facility> GetFacilityById(int id);
    }
}