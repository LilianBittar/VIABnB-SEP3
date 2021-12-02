using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostService
    {
        /// <summary>
        /// create a new host and stores it in the system
        /// </summary>
        /// <param name="host"></param>
        /// <returns> the created host</returns>
        Task<Host> RegisterHostAsync(Host host);
        
        /// <summary>
        /// a method to validate the host
        /// </summary>
        /// <param name="email" name="password"></param>
        /// <returns> the guest representing the authenticated user from the parameters</returns>
        Task<Host> ValidateHostAsync(string email, string password);
        
        /// <summary>
        /// a method to get a host by using his email
        /// </summary>
        /// <param name="email"></param>
        /// <returns> the host with this specific email</returns>
        Task<Host> GetHostByEmail(string email);
        
        /// <summary>
        /// a method to get a host by using his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> the host with this specific id</returns>
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
        
        /// <summary>
        /// a method to update the host information 
        /// </summary>
        /// <param name="host"></param>
        /// <returns> the newly updated host information</returns>
        Task<Host> UpdateHost(Host host);

    }
}