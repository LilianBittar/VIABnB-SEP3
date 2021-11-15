using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Administration
{
    //Host
    public interface IAdministrationService
    {
        Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequests();
        Task<HostRegistrationRequest> GetHostRegistrationRequestsByHostId(int hostId);
        Task<HostRegistrationRequest> GetHostRegistrationRequestById(int requestId);
        Task IsValidHost(int requestId, RequestStatus status);
        //Guest
        Task<IList<GuestRegistrationRequest>> GetAllGuestRegistrationRequests();
        Task<GuestRegistrationRequest> GetGuestRegistrationRequestsByHostId(int hostId);
        Task<GuestRegistrationRequest> GetGuestRegistrationRequestById(int requestId);
        Task IsValidGuest(int requestId, RequestStatus status);
    }
}