using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services;

namespace SEP3T2GraphQL.Graphql
{
    public class Mutation
    {
        private readonly IResidenceService _residenceService;
        private readonly IHostService _hostService;
        private readonly IGuestService _guestService; 
        public Mutation(IResidenceService residenceService, IHostService hostService, IGuestService guestService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
            _guestService = guestService;
        }
        public async Task<Residence> CreateResidence(Residence residence)
        {
            return await _residenceService.CreateResidenceAsync(residence); 
        }

        public async Task<Host> UpdateHostStatus(Host host)
        {
            return await _hostService.UpdateHost(host);
        }

        public async Task<Guest> CreateGuest(Guest guest)
        {
            return await _guestService.CreateGuestAsync(guest); 
        }
    }
}