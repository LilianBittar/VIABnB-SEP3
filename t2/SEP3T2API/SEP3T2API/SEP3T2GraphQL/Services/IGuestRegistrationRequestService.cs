using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IGuestRegistrationRequestService
    {
        Task<GuestRegistrationRequest> CreateGuestRegistrationRequest(GuestRegistrationRequest guestRegistrationRequest); 
        Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequests();
        Task<GuestRegistrationRequest> ApproveGusetRegistrationRequset(int requestId); 
        Task<GuestRegistrationRequest> RejectGusetRegistrationRequset(int requestId); 

    }
}