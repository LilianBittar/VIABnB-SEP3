using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IUserService
    {
        /// <summary>
        /// Get a User object based on the given parameter via repository
        /// </summary>
        /// <param name="email">The targeted User's e-mail</param>
        /// <returns>A user object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<User> GetUserByEmailAsync(string email);
        /// <summary>
        /// Validate a User by the given parameters
        /// </summary>
        /// <param name="email">The User's e-mail</param>
        /// <param name="password">The User's password</param>
        /// <returns>User object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<User> ValidateUserAsync(string email, string password);
        /// <summary>
        /// Update a User object via repository
        /// </summary>
        /// <param name="user">The updated User object</param>
        /// <returns>The updated User object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<User> UpdateUserAsync(User user);
        /// <summary>
        /// Delete User object via repository  
        /// </summary>
        /// <param name="user">The User object to be deleted</param>
        /// <returns>The deleted User object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<User> DeleteUserAsync(User user);
    }
}