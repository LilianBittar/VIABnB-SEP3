using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IHostRepository
    {
        /// <summary>
        /// Method that returns a host registration based on the given parameter
        /// </summary>
        /// <param name="host">The Id of the host object that created the registration</param>
        /// <returns>Host object</returns>
        Task<Host> RegisterHostAsync(Host host);
        Task<Host> GetHostByEmail(string email);
        Task<Host> GetHostById(int id);
        Task<Host> ValidateHostAsync(Host host);
    }
}