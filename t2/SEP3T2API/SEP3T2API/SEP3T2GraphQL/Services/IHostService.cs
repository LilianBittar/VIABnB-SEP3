using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IHostService
    {
        /// <summary>
        /// Create a new Host object via repository
        /// </summary>
        /// <param name="host">The new Host</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.ArgumentException">If the Host's e-mail is already taken</exception>
        /// <exception cref="System.FormatException">If the Host's e-mail is null or is not composed of dot (.) that is not in the end of the email or does not bass the system's email checker</exception>
        /// <exception cref="System.ArgumentException">If the first name is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the last name is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the password is null, empty string length below 8 or is not composed of capital and lower cases and numbers</exception>
        /// <exception cref="System.ArgumentException">If the CPR number is null, empty string or not of a 10 or 11 with a (-)</exception>

        Task<Host> RegisterHostAsync(Host host);
        /// <summary>
        /// Validate a Host
        /// </summary>
        /// <param name="email">The Host's e-mail</param>
        /// <param name="password">The Host's id</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.KeyNotFoundException">If the returned Host is null</exception>
        /// <exception cref="System.ArgumentException">If the argument password does not match the Host's password</exception>
        Task<Host> ValidateHostAsync(string email, string password);
        /// <summary>
        /// Get a Host object based on the given parameter via repository
        /// </summary>
        /// <param name="email">The host's e-mail</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.Exception">If the API cant execute the method</exception>
        Task<Host> GetHostByEmailAsync(string email);
        /// <summary>
        /// Get a Host object by the given parameter via repository
        /// </summary>
        /// <param name="id">The targeted Host's id</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.Exception">If the Host's id is a negative number</exception>
        /// <exception cref="System.Exception">If the API cant execute the method</exception>
        Task<Host> GetHostByIdAsync(int id);
        /// <summary>
        /// Get a list of Host object with a false IsApproved status via repository
        /// </summary>
        /// <returns>A list of Host objects</returns>
        /// <exception cref="System.ArgumentException">If the returned list is null</exception>
        Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync();
        /// <summary>
        /// Update a Host object via repository
        /// </summary>
        /// <param name="host">The updated host object</param>
        /// <returns>Host object</returns>
        /// <exception cref="System.ArgumentException">If the Host is null</exception>
        /// <exception cref="System.ArgumentException">If the returned Host is null</exception>
        Task<Host> UpdateHostStatusAsync(Host host);
    }
}