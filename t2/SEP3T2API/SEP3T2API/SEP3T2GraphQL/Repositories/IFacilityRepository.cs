using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IFacilityRepository
    {
        Task<Facility> CreateResidenceFacilityAsync(Facility facility, int residenceId);
        Task<IEnumerable<Facility>> GetAllFacilitiesAsync();
        Task<Facility> GetFacilityByIdAsync(int id);
        Task<Facility> DeleteResidenceFacilityAsync(Facility facility, int residenceId);
    }
}