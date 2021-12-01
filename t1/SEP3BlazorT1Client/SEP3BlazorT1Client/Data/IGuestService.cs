using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IGuestService
    {
        /// <summary>
        /// create a new guest and stores it in the system
        /// </summary>
        /// <param name="guest"></param>
        /// <returns> the created guest</returns>
        Task<Guest> CreateGuestAsync(Guest guest);
        
        /// <summary>
        /// a method to get a guest by using his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> the guest with this specific id</returns>
        Task<Guest> GetGuestById(int id);
        
        /// <summary>
        /// a method to get a guest by using his email
        /// </summary>
        /// <param name="email"></param>
        /// <returns> the guest with this specific email</returns>
        Task<Guest> GetGuestByEmail(string email);
        
        /// <summary>
        /// a method to update the guest information 
        /// </summary>
        /// <param name="guest"></param>
        /// <returns> the newly updated guest information</returns>
        Task<Guest> UpdateGuest(Guest guest); 
        
        /// <summary>
        /// a method to get all the guests
        /// </summary>
        /// <returns> a list with all the guests stored in the system</returns>
        /// 
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
        
        /// <summary>
        /// a method to validate the guest
        /// </summary>
        /// <param name="email" name="password"></param>
        /// <returns> the guest representing the authenticated user from the parameters</returns>
        Task<Guest> ValidateGuestAsync(string email, string password);
        
    }
}