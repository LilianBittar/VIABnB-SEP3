using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IResidenceRepository
    {
        Task<Residence> GetResidenceByIdAsync(int id);
        Task<Residence> CreateResidenceAsync(Residence residence);
        Task<IList<Residence>> ShowAllRegisteredResidencesByHostAsync(Host host);
    }
}