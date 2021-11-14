using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Administration
{
    //Host
    public interface IAdministrationService
    {
        Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequests();
        Task<IList<HostRegistrationRequest>> GetHostRegistrationRequestsByHostId(int hostId);
        Task<HostRegistrationRequest> GetHostRegistrationRequestsById(int requestId);
        Task IsValidHost(int requestId, RequestStatus status);
        //Guest
        Task<IList<GuestRegistrationRequest>> GetAllGuestRegistrationRequests();
        Task<IList<GuestRegistrationRequest>> GetGuestRegistrationRequestsByHostId(int hostId);
        Task<GuestRegistrationRequest> GetGuestRegistrationRequestsById(int requestId);
        Task IsValidGuest(int requestId, RequestStatus status);
    }
}