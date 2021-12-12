using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IResidenceRepository
    {
        Task<Residence> GetResidenceByIdAsync(int id);
        Task<Residence> CreateResidenceAsync(Residence residence);
        Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence);
        Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id);
        Task<IList<Residence>> GetAllResidenceAsync();
        Task<Residence> UpdateResidenceAsync(Residence residence);
        Task<Residence> DeleteResidenceAsync(Residence residence);
    }
}