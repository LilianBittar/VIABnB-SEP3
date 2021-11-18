using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class GuestServiceImpl : IGuestService
    {
        private IGuestRepository _guestRepository;

        public GuestServiceImpl(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            GuestValidator.ValidateGuest(guest);
            var allGuests = await GetAllGuests();
            foreach (var g in allGuests)
            {
                if (g.ViaId == guest.ViaId)
                {
                    throw new ArgumentException("Guest with provided student number already exists"); 
                }
            }

            guest.IsApprovedGuest = false; 
            var newGuest = await _guestRepository.CreateGuestAsync(guest);
            return newGuest; 
        }
    }
}