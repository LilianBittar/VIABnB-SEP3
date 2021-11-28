using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IGuestService
    {
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<Guest> GetGuestById(int id);
        Task<Guest> GetGuestByEmail(string email);
        Task<Guest> UpdateGuest(Guest guest); 
        Task<IEnumerable<Guest>> GetAllGuests(); 
        /// <summary>
        /// Method that returns a list of Guest objects of a IsApprovedGuest value false from a GraphQl server
        /// </summary>
        /// <returns>IEnumerable<Guest> list of Guest objects</returns>
        Task<IEnumerable<Guest>> GetAllNotApprovedGuests();
        /// <summary>
        /// Method that updates the bool value IsApprovedGuest of a given host using a GraphQl server
        /// </summary>
        /// <param name="guest">The targeted Guest object to update</param>
        /// <exception cref="ArgumentException">Thrown if the mutation response is null</exception>
        /// <returns>Guest object</returns>
        Task<Host> UpdateGuestStatusAsync(Guest guest);
        
        Task<Guest> ValidateGuestAsync(  string studentNumber,string password);
        
    }
}