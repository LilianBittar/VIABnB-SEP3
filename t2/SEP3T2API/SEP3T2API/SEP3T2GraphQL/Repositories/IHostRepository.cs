using System.Collections.Generic;
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
        Task<Host> GetHostByEmailAsync(string email);
        Task<Host> GetHostByIdAsync(int id);
        /// <summary>
        /// Method that returns a list of Host objects with IsApprovedHost bool value of false
        /// </summary>
        /// <exception cref="Exception"> Thrown if the API response is not successful</exception>
        /// <returns>IEnumerable<Host> a lit of Host objects</returns>
        Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync();
        /// <summary>
        /// Method that updates the bool value IsApprovedHost of a given host
        /// </summary>
        /// <param name="host">The targeted Host object to update</param>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>Host object</returns>
        Task<Host> UpdateHostStatusAsync(Host host);
    }
}