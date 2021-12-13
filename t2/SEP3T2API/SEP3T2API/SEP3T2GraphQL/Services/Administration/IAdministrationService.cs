using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Administration
{
    public interface IAdministrationService
    {
        /// <summary>
        /// Get an Administrator object based on the given parameter via repository
        /// </summary>
        /// <param name="email">The Administrator's e-mail</param>
        /// <returns>Administrator object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Administrator> GetAdminByEmail(string email);
        /// <summary>
        /// Get a list of Administrator objects via repository
        /// </summary>
        /// <returns>List of Administrator object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<Administrator>> GetAllAdmins();
        Task<Administrator> ValidateAdmin(string email, string password);
    }
}