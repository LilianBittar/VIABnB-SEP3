using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services;

namespace SEP3T2GraphQL.Graphql
{
    public class Mutation
    {
        private IResidenceService _residenceService;
        private IGuestRegistrationRequestService _guestRegistrationRequestService;
        public Mutation(IResidenceService residenceService, IGuestRegistrationRequestService guestRegistrationRequestService)
        {
            _residenceService = residenceService;
            _guestRegistrationRequestService = guestRegistrationRequestService; 
        }
        public async Task<Residence> CreateResidence(Residence residence)
        {
            return await _residenceService.CreateResidenceAsync(residence); 
        }

        public async Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(GuestRegistrationRequest guestRegistrationRequest)
        {
            return await _guestRegistrationRequestService.CreateGuestRegistrationRequest(guestRegistrationRequest); 
        }
    }
}