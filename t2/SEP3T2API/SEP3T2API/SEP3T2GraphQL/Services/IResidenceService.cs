using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services
{
    public interface IResidenceService
    {
        Task<Residence> GetResidenceByIdAsync(int id);
        Task CreateResidenceAsync(Residence residence); 
    }
}