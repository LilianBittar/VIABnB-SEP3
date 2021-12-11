using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IFacilityRepository
    {
        Task<Facility> CreateResidenceFacility(Facility facility, int residenceId);
        Task<IEnumerable<Facility>> GetAllFacilities();
        Task<Facility> GetFacilityById(int id);
        Task<Facility> DeleteResidenceFacility(Facility facility, int residenceId);
    }
}