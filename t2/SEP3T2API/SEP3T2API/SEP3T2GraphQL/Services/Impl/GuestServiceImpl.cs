using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            Console.WriteLine($"{this} {nameof(CreateGuestAsync)} received params : {JsonSerializer.Serialize(guest)}");
            if (guest == null)
            {
                throw new ArgumentException("guest cannot be null");
            }

            Host existingHost = null;
            try
            {
                existingHost = await _hostService.GetHostById(guest.Id);
             
            }
            catch (NullReferenceException e)
            {
                throw new KeyNotFoundException("Host does not exist");
            }
            
            GuestValidator.ValidateGuest(guest);
            var allGuests = await GetAllGuests();
            Console.WriteLine($"{this} {nameof(CreateGuestAsync)} received allGuests : {JsonSerializer.Serialize(allGuests, new JsonSerializerOptions(){WriteIndented = true})}");

            if (allGuests.Any(g => g.ViaId == guest.ViaId))
            {
                Console.WriteLine($"{this} {nameof(CreateGuestAsync)} found guest with matching student number/viaId");

                throw new ArgumentException("Guest with provided student number already exists");
            }

            guest.IsApprovedGuest = false;
            var newGuest = await _guestRepository.CreateGuestAsync(guest);
            if (newGuest == null)
            {
                throw new Exception("Could not create new guest..."); 
            }
            return newGuest;
        }
    }
}