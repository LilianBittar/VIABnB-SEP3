using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IAdministrationService
    {
        //Todo check host methods. maybe IsValidHost should be split in two-> look the guest approve and reject, and name change
        //Host
        Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequestsAsync();
        Task<HostRegistrationRequest> GetHostRegistrationRequestsByHostIdAsync(int hostId);
        Task<HostRegistrationRequest> GetHostRegistrationRequestByIdAsync(int requestId);
        Task IsValidHost(int requestId, RequestStatus status);
        //Guest
        Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(GuestRegistrationRequest guestRegistrationRequest); 
        Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync();
        Task<GuestRegistrationRequest> ApproveGuestRegistrationRequestAsync(int requestId); 
        Task<GuestRegistrationRequest> RejectGuestRegistrationRequestAsync(int requestId); 
    }
}