using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public partial class GraphQlGuestService : IGuestService
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