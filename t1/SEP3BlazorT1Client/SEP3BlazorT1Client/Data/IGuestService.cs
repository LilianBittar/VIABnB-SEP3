using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IGuestService
    {
        /// <summary>
        /// Creates a new guest
        /// </summary>
        /// <param name="guest">the guest to be created</param>
        /// <returns>the created guest</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Guest> CreateGuestAsync(Guest guest);
        /// <summary>
        /// Get a Guest object based on the given parameter via API
        /// </summary>
        /// <param name="id">The Guest's id</param>
        /// <returns>Guest object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Guest> GetGuestByIdAsync(int id);
        /// <summary>
        /// Get a Guest object based on the given parameter via API
        /// </summary>
        /// <param name="email">The Guest's e-mail</param>
        /// <returns>A Guest object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Guest> GetGuestByEmailAsync(string email);
        /// <summary>
        /// Method that returns a list of Guest objects of a IsApprovedGuest value false from a repository
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the guest list is null</exception>
        /// <returns>IEnumerable<Guest> list of Guest objects</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IEnumerable<Guest>> GetAllNotApprovedGuestsAsync();

        /// <summary>
        /// Method that updates the bool value IsApprovedGuest of a given host from a repository
        /// </summary>
        /// <param name="guest">The targeted Guest object to update</param>
        /// <returns>Guest object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Host> UpdateGuestStatusAsync(Guest guest);
    }
}