using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get a User object based on the given parameter via API
        /// </summary>
        /// <param name="email">The targeted User's e-mail</param>
        /// <returns>A user object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<User> GetUserByEmailAsync(string email);
        /// <summary>
        /// Get a User object based on the given parameter via API
        /// </summary>
        /// <param name="id">The targeted User's id</param>
        /// <returns>A user Object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<User> GetUserByIdAsync(int id);
        /// <summary>
        /// Get a list of User object via API
        /// </summary>
        /// <returns>A list of User objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<User>> GetAllUsersAsync();
        /// <summary>
        /// Update a User object via API
        /// </summary>
        /// <param name="user">The updated User object</param>
        /// <returns>The updated User object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<User> UpdateUserAsync(User user);
        /// <summary>
        /// Delete User object via API  
        /// </summary>
        /// <param name="user">The User object to be deleted</param>
        /// <returns>The deleted User object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<User> DeleteUserAsync(User user);
    }
}