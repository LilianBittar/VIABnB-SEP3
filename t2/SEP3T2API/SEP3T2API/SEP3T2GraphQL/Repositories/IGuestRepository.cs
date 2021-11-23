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
        Task<IEnumerable<Guest>> GetAllGuests(); 
        Task<IEnumerable<Guest>> GetAllNotApprovedGuests();
        Task<Guest> UpdateGuestStatus(Guest guest); 
    }
}