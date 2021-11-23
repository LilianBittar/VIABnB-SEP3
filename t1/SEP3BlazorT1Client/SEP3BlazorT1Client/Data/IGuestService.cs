using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IGuestService
    {
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<Guest> GetGuestById(int id);
        Task<Guest> GetGuestByEmail(string email);
        Task<Guest> UpdateGuest(Guest guest); 
        Task<IEnumerable<Guest>> GetAllGuests(); 
        Task<IEnumerable<Guest>> GetAllNotApprovedGuests();
        Task<Host> UpdateGuestStatusAsync(Guest guest);
    }
}