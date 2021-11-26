using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IFacilityRepository
    {
        Task<Facility> CreateFacility(Facility facility);
        Task<IEnumerable<Facility>> GetAllFacilities();
        Task<Facility> GetFacilityById(int id);
    }
}