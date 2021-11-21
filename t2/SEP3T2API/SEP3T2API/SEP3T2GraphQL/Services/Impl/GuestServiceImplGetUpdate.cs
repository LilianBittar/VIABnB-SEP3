using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

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
            return await _guestRepository.UpdateGuest(guest);
        }

        public async Task<IList<Guest>> GetAllGuests()
        {
            return await _guestRepository.GetAllGuests(); 
        }

        public async Task<IList<Guest>> GetAllNotApprovedGuests()
        {
            return await _guestRepository.GetAllNotApprovedGuests();
        }
    }
}