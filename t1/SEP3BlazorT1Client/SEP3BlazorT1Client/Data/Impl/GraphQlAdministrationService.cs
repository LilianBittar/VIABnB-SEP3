using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlAdministrationService : IAdministrationService
    {
        public Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(GuestRegistrationRequest guestRegistrationRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestRegistrationRequest> ApproveGuestRegistrationRequestAsync(int requestId)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestRegistrationRequest> RejectGuestRegistrationRequestAsync(int requestId)
        {
            throw new System.NotImplementedException();
        }
    }
}