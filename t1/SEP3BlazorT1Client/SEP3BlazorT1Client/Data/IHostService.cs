using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostService
    {
        /// <summary>
        /// Create a new Host object via repository
        /// </summary>
        /// <param name="host">The new Host</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Host> RegisterHostAsync(Host host);
        /// <summary>
        /// Get a Host object based on the given parameter via repository
        /// </summary>
        /// <param name="email">The host's e-mail</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Host> GetHostByEmailAsync(string email);
        /// <summary>
        /// Get a Host object by the given parameter via repository
        /// </summary>
        /// <param name="id">The targeted Host's id</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Host> GetHostByIdAsync(int id);
        /// <summary>
        /// Get a list of Host object with a false IsApproved status via repository
        /// </summary>
        /// <returns>A list of Host objects</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync();

        /// <summary>
        /// Update a Host object via repository
        /// </summary>
        /// <param name="host">The updated host object</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Host> UpdateHostStatusAsync(Host host);
    }
}