using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IGuestRepository
    {
        /// <summary>
        /// Create a new Guest object via API
        /// </summary>
        /// <param name="guest">The new Guest</param>
        /// <returns>Guest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Guest> CreateGuestAsync(Guest guest);
        /// <summary>
        /// Get a Guest object based on the given parameter via API
        /// </summary>
        /// <param name="id">The Guest's id</param>
        /// <returns>Guest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Guest> GetGuestByIdAsync(int id);
        /// <summary>
        /// Get a Guest object based on the given parameter via API
        /// </summary>
        /// <param name="studentNumber">The Guest's ViaId</param>
        /// <returns>Guest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Guest> GetGuestByStudentNumberAsync(int studentNumber);
        /// <summary>
        /// Get a Guest object based on the given parameter via API
        /// </summary>
        /// <param name="email">The Guest's e-mail</param>
        /// <returns>A Guest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Guest> GetGuestByEmailAsync(string email);
        /// <summary>
        /// Get a list of Guest objects via API
        /// </summary>
        /// <returns>List of Guest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<Guest>> GetAllGuestsAsync(); 
        /// <summary>
        /// Get a list of Guest objects via API
        /// </summary>
        /// <returns>List of Guest objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<Guest>> GetAllNotApprovedGuestsAsync();
        /// <summary>
        /// Update a Guest object via API
        /// </summary>
        /// <param name="guest">TThe updated Guest</param>
        /// <returns>Guest object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Guest> UpdateGuestStatusAsync(Guest guest); 
        
        
    }
}