using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public class HostRegistrationRequestServiceImpl : IHostRegistrationRequestService
    {
        private IHostRegistrationRequestRepository hostRegistrationRequestRepository;

        public HostRegistrationRequestServiceImpl(IHostRegistrationRequestRepository hostRegistrationRequestRepository)
        {
            this.hostRegistrationRequestRepository = hostRegistrationRequestRepository;
        }

        public async Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequestsAsync()
        {
            return await hostRegistrationRequestRepository.GetAllHostRegistrationRequests();
        }

        public async Task<HostRegistrationRequest> GetHostRegistrationRequestByHostIdAsync(int hostId)
        {
            return await hostRegistrationRequestRepository.GetHostRegistrationRequestByHostId(hostId);
        }

        public async Task<HostRegistrationRequest> GetHostRegistrationRequestByIdAsync(int requestId)
        {
            return await hostRegistrationRequestRepository.GetHostRegistrationRequestById(requestId);
        }

        public async Task UpdateHostRegistrationRequestAsync(HostRegistrationRequest request)
        {
            await hostRegistrationRequestRepository.UpdateHostRegistrationRequest(request);
        }
    }
}