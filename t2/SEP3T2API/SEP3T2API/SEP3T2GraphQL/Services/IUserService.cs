using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Get a User object based on the given parameter via repository
        /// </summary>
        /// <param name="email">The targeted User's e-mail</param>
        /// <returns>A user object</returns>
        /// <exception cref="System.Exception">Thrown if the API throws exceptions</exception>

        Task<User> GetUserByEmailAsync(string email);
        /// <summary>
        /// Get a User object based on the given parameter via repository
        /// </summary>
        /// <param name="id">The targeted User's id</param>
        /// <returns>A user Object</returns>
        /// <exception cref="System.Exception">Thrown if the API throws exceptions</exception>

        Task<User> GetUserByIdAsync(int id);
        /// <summary>
        /// Get a list of User object via repository
        /// </summary>
        /// <returns>A list of User objects</returns>
        /// <exception cref="System.Exception">Thrown if the API throws exceptions</exception>
        Task<IEnumerable<User>> GetAllUsersAsync();
        /// <summary>
        /// Validate a User by the given parameters
        /// </summary>
        /// <param name="email">The User's e-mail</param>
        /// <param name="password">The User's password</param>
        /// <returns>User object</returns>
        /// <exception cref="System.ArgumentException">If the User is null</exception>
        /// <exception cref="System.ArgumentException">If the password argument does not matches the User's password</exception>
        Task<User> ValidateUserAsync(string email, string password);
        /// <summary>
        /// Update a User object via repository
        /// </summary>
        /// <param name="user">The updated User object</param>
        /// <returns>The updated User object</returns>
        /// <exception cref="System.ArgumentException">If the first name is null or not composed of letters only</exception>
        /// <exception cref="System.ArgumentException">If the last name is null or not composed of letters only</exception>
        /// <exception cref="System.ArgumentException">If the password null or not composed of the combination of capital, small letters, numbers and a length of minimum 8 characters</exception>
        /// <exception cref="System.ArgumentException">If the phone number is null or is not composed of numbers only and a length of 8 characters</exception>
        Task<User> UpdateUserAsync(User user);
        /// <summary>
        /// Delete User object via repository  
        /// </summary>
        /// <param name="user">The User object to be deleted</param>
        /// <returns>The deleted User object</returns>
        /// <exception cref="System.ArgumentException">If the User id is a negative number</exception>
        Task<User> DeleteUserSync(User user);
    }
}