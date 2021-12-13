using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IHostRepository
    {
        /// <summary>
        /// Create a new Host object via API
        /// </summary>
        /// <param name="host">The new Host</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Host> RegisterHostAsync(Host host);
        /// <summary>
        /// Get a Host object based on the given parameter via API
        /// </summary>
        /// <param name="email">The host's e-mail</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Host> GetHostByEmailAsync(string email);
        /// <summary>
        /// Get a Host object by the given parameter via API
        /// </summary>
        /// <param name="id">The targeted Host's id</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Host> GetHostByIdAsync(int id);
        /// <summary>
        /// Get a list of Host object with a false IsApproved status via API
        /// </summary>
        /// <returns>A list of Host objects</returns>
        /// <exception cref="System.Exception"> Thrown if the API response is not successful</exception>
        Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync();
        /// <summary>
        /// Update a Host object via API
        /// </summary>
        /// <param name="host">The updated host object</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Host> UpdateHostStatusAsync(Host host);
    }
}