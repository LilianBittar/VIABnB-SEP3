using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class GuestServiceImpl : IGuestService
    {
        public async Task<Guest> GetGuestById(int id)
        {
            return await _guestRepository.GetGuestById(id); 
        }

        public Task<Guest> GetGuestByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Guest> UpdateGuest(Guest guest)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Guest>> GetAllGuests()
        {
            return await _guestRepository.GetAllGuests(); 
        }

        public async Task<IList<Guest>> GetAllNotApprovedGuests()
        {
            return await _guestRepository.GetAllNotApprovedGuests();
        }

        public async Task<Guest> UpdateGuestStatus(Guest guest)
        {
            Console.WriteLine($"{this} {nameof(UpdateGuestStatus)} received params: {JsonSerializer.Serialize(guest)}");
            if (guest == null)
            {
                throw new ArgumentException("Guest can't be null");
            }

            var updatedGuest = await _guestRepository.UpdateGuestStatus(guest);
            if (updatedGuest == null)
            {
                throw new Exception("Can't update the guest status!!!");
            }

            return updatedGuest;
        }
    }
}