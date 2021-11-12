using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IGuestRegistrationRequestService
    {
        Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(GuestRegistrationRequest guestRegistrationRequest); 
        Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync();
        Task<GuestRegistrationRequest> ApproveGuestRegistrationRequestAsync(int requestId); 
        Task<GuestRegistrationRequest> RejectGuestRegistrationRequestAsync(int requestId); 

    }
}