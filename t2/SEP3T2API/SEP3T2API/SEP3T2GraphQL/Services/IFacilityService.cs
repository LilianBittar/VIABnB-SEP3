using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IFacilityService
    {
        Task<Facility> CreateResidenceFacility(Facility facility, int residenceId);
        Task<IEnumerable<Facility>> GetAllFacilities();
        Task<Facility> GetFacilityById(int id);
        Task<Facility> DeleteResidenceFacilityAsync(Facility facility, int residenceId);
    }
}