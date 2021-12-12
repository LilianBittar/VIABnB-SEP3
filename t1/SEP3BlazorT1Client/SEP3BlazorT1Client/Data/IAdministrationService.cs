using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IAdministrationService
    {
        /// <summary>
        /// Get an Administrator object based on the given parameter via repository
        /// </summary>
        /// <param name="email">The Administrator's e-mail</param>
        /// <returns>Administrator object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Administrator> GetAdminByEmailAsync(string email);
    }
}