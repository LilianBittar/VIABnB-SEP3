using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IFacilityService
    {
        Task<Facility> CreateFacility(Facility facility);
        Task<IEnumerable<Facility>> GetAllFacilities();
        Task<Facility> GetFacilityById(int id);
        Task DeleteResidenceFacilityAsync(int facilityId, int residenceId);
    }
}