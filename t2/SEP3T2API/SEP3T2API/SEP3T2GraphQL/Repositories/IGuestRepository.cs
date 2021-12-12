using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IGuestRepository
    {
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<Guest> GetGuestByIdAsync(int id);
        Task<Guest> GetGuestByStudentNumberAsync(int studentNumber);
        Task<Guest> GetGuestByEmailAsync(string email);
        Task<IEnumerable<Guest>> GetAllGuestsAsync(); 
        /// <summary>
        /// Method that returns a list of Guest objects of a IsApprovedGuest value false
        /// </summary>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>IEnumerable<Guest> list of Guest objects</returns>
        Task<IEnumerable<Guest>> GetAllNotApprovedGuestsAsync();
        /// <summary>
        /// Method that updates the bool value IsApprovedGuest of a given host
        /// </summary>
        /// <param name="guest">The targeted Guest object to update</param>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>Guest object</returns>
        Task<Guest> UpdateGuestStatusAsync(Guest guest); 
        
        
    }
}