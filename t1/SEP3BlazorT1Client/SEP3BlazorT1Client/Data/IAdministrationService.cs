using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IAdministrationService
    {
        /// <summary>
        /// a method to get the admin by his email
        /// </summary>
        /// <param name="email"></param>
        /// <returns> the admin  for this specific email</returns>
        Task<Administrator> GetAdminByEmail(string email);
        
        /// <summary>
        /// a method to retrieve a list of all admins
        /// </summary>
        /// <returns> a list containing all the admins</returns>
        Task<IEnumerable<Administrator>> GetAllAdmins();
        
        /// <summary>
        /// a method to validate the admin 
        /// </summary>
        /// <param name="email" name="password"></param>
        /// <returns> the an administrator class if the validation was success</returns>
        Task<Administrator> ValidateAdmin(string email, string password);
    }
}