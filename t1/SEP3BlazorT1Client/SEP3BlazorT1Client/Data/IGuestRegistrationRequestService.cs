using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IGuestRegistrationRequestService
    {
        Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(GuestRegistrationRequest guestRegistrationRequest); 
        Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync();
        /*Task<GuestRegistrationRequest> ApproveGuestRegistrationRequestAsync(int requestId); 
        Task<GuestRegistrationRequest> RejectGuestRegistrationRequestAsync(int requestId); */
        Task UpdateGuestRegistrationRequestAsync(GuestRegistrationRequest request);
    }
}