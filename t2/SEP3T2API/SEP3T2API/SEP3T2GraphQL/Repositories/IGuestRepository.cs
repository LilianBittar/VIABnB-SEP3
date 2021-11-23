using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IGuestRepository
    {
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<Guest> GetGuestById(int id);
        Task<Guest> GetGuestByEmail(string email);
        Task<Guest> UpdateGuest(Guest guest); 
        Task<IEnumerable<Guest>> GetAllGuests(); 
        /// <summary>
        /// Method that returns a list of Guest objects of a IsApprovedGuest value false
        /// </summary>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>IEnumerable<Guest> list of Guest objects</returns>
        Task<IEnumerable<Guest>> GetAllNotApprovedGuests();
        /// <summary>
        /// Method that updates the bool value IsApprovedGuest of a given host
        /// </summary>
        /// <param name="guest">The targeted Guest object to update</param>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>Guest object</returns>
        Task<Guest> UpdateGuestStatus(Guest guest); 
    }
}