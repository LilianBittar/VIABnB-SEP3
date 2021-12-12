using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services
{
    public interface IGuestService
    {
        /// <summary>
        /// Creates a new guest
        /// </summary>
        /// <param name="guest">the guest to be created</param>
        /// <exception cref="ArgumentException">If guest is null</exception>
        /// <exception cref="KeyNotFoundException">If host does not exist in the system</exception>
        /// <exception cref="ArgumentException">If guest is invalid <see cref="CreateGuestValidator"/></exception>
        /// <returns>the created guest</returns>
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<Guest> GetGuestByIdAsync(int id);
        Task<Guest> GetGuestByStudentNumberAsync(int studentNumber);
        Task<Guest> GetGuestByEmailAsync(string email);
        /// <summary>
        /// Method that returns a list of Guest objects of a IsApprovedGuest value false from a repository
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the guest list is null</exception>
        /// <returns>IEnumerable<Guest> list of Guest objects</returns>
        Task<IEnumerable<Guest>> GetAllNotApprovedGuestsAsync();
        /// <summary>
        /// Method that updates the bool value IsApprovedGuest of a given host from a repository
        /// </summary>
        /// <param name="guest">The targeted Guest object to update</param>
        /// <exception cref="ArgumentException">Thrown if the host is null</exception>
        /// <returns>Guest object</returns>
        Task<Guest> UpdateGuestStatusAsync(Guest guest);
        Task<Guest> ValidateGuestAsync(string email, string password);
    }
}