using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IGuestRepository
    {
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<Guest> GetGuestById(int id);
        Task<Guest> GetGuestByEmail(string email);
        Task<Guest> UpdateGuest(Guest guest); 
        Task<IList<Guest>> GetAllGuests(); 
        Task<IList<Guest>> GetAllNotApprovedGuests();
    }
}