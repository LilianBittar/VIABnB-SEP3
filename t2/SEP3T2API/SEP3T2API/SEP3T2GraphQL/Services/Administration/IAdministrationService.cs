using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Administration
{
    public interface IAdministrationService
    {
        Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequests();
        Task<IList<HostRegistrationRequest>> GetHostRegistrationRequestsByHostId(int hostId);
        Task<HostRegistrationRequest> GetHostRegistrationRequestsById(int requestId);
        Task IsValidHost(int requestId, RequestStatus status);
    }
}