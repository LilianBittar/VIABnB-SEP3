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

        public Task<Guest> UpdateGuest(Guest guest)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Guest>> GetAllGuests()
        {
            return await _guestRepository.GetAllGuests(); 
        }

        public Task<IList<Guest>> GetAllNotApprovedGuests()
        {
            throw new System.NotImplementedException();
        }
    }
}