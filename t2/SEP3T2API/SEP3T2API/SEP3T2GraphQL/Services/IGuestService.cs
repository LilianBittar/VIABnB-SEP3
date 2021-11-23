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
        /// <exception cref="ArgumentException">If guest is invalid <see cref="GuestValidator"/></exception>
        /// <returns>the created guest</returns>
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<Guest> GetGuestById(int id);
        Task<Guest> GetGuestByEmail(string email);
        Task<Guest> UpdateGuest(Guest guest); 
        Task<IList<Guest>> GetAllGuests(); 
        Task<IList<Guest>> GetAllNotApprovedGuests();
        Task<Guest> UpdateGuestStatus(Guest guest);
    }
}