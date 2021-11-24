using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IHostService
    {
        Task<Host> UpdateHost(Host host);
        Task<Host> RegisterHostAsync(Host host);
        Task<Host> ValidateHostAsync(string email, string password);
        Task<Host> GetHostByEmail(string email);
        Task<Host> GetHostById(int id);
        /// <summary>
        /// Method that returns a list of Host objects with IsApprovedHost bool value of false from a repository
        /// </summary>
        /// <exception cref="ArgumentException">Thrown If the host list is null</exception>
        /// <returns>IEnumerable<Host> a lit of Host objects</returns>
        Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync();
        /// <summary>
        /// Method that updates the bool value IsApprovedHost of a given host from a repository
        /// </summary>
        /// <param name="host">The targeted Host object to update</param>
        /// <exception cref="ArgumentException">Thrown if the host is null</exception>
        /// <returns>Host object</returns>
        Task<Host> UpdateHostStatusAsync(Host host);
    }
}