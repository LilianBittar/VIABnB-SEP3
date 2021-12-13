using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class GuestService : IGuestService
    {
        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _guestRepository.GetGuestByIdAsync(id); 
        }

        public async Task<Guest> GetGuestByEmailAsync(string email)
        {
            return await _guestRepository.GetGuestByEmailAsync(email);
        }
        public async Task<IEnumerable<Guest>> GetAllNotApprovedGuestsAsync()
        {
            var guestListToReturn = await _guestRepository.GetAllNotApprovedGuestsAsync();
            if (guestListToReturn == null)
            {
                throw new ArgumentException("Guest list is null");
            }

            return guestListToReturn;
        }

        public async Task<Guest> UpdateGuestStatusAsync(Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentException("Guest can't be null");
            }

            var updatedGuest = await _guestRepository.UpdateGuestStatusAsync(guest);
            if (updatedGuest == null)
            {
                throw new ArgumentException("Can't update the guest status!!!");
            }

            return updatedGuest;
        }
    }
}