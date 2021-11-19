using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class GuestServiceImpl : IGuestService
    {
        private IGuestRepository _guestRepository;
        private IHostService _hostService; 

        public GuestServiceImpl(IGuestRepository guestRepository, IHostService hostService)
        {
            _guestRepository = guestRepository;
            _hostService = hostService;
        }

        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentException("guest cannot be null"); 
            }
            var existingHost = await _hostService.GetHostById(guest.Id);
            if (existingHost == null)
            {
                throw new KeyNotFoundException("Host does not exist"); 
            }
            
            GuestValidator.ValidateGuest(guest);
            var allGuests = await GetAllGuests();
            if (allGuests.Any(g => g.ViaId == guest.ViaId))
            {
                throw new ArgumentException("Guest with provided student number already exists");
            }

            guest.IsApprovedGuest = false; 
            var newGuest = await _guestRepository.CreateGuestAsync(guest);
            return newGuest; 
        }
    }
}