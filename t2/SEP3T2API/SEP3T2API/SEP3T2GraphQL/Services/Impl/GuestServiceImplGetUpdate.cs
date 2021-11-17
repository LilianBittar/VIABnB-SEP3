using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class GuestServiceImpl : IGuestService
    {
        public Task<Guest> GetGuestById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Guest> GetGuestByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<Guest> UpdateGuest(Guest guest)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Guest>> GetAllGuests()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Guest>> GetAllNotApprovedGuests()
        {
            throw new System.NotImplementedException();
        }
    }
}