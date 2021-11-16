using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostRegistrationRequestService
    {
        Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequestsAsync();
        Task<HostRegistrationRequest> GetHostRegistrationRequestByHostIdAsync(int hostId);
        Task<HostRegistrationRequest> GetHostRegistrationRequestByIdAsync(int requestId);
        Task UpdateHostRegistrationRequestAsync(HostRegistrationRequest request); 
    }
}