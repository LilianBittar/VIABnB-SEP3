using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostService
    {
        Task<Host> RegisterHostAsync(Host host);
        Task<Host> ValidateHostAsync(string email, string password);
        Task<Host> GetHostByEmail(string email);
        Task<Host> GetHostById(int id);
        /// <summary>
        /// Method that returns a list of Host objects with IsApprovedHost bool value of false from a GraphQl server
        /// </summary>
        /// <returns>IEnumerable<Host> a lit of Host objects</returns>
        Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync();
        /// <summary>
        /// Method that updates the bool value IsApprovedHost of a given host from a repository using a GraphQl server
        /// </summary>
        /// <param name="host">The targeted Host object to update</param>
        /// <exception cref="ArgumentException">Thrown if the mutation response is null</exception>
        /// <returns>Host object</returns>
        Task<Host> UpdateHostStatusAsync(Host host);
        Task<Host> UpdateHost(Host host);

    }
}