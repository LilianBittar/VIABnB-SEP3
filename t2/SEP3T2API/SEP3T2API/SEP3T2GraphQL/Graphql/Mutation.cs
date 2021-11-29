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
        private readonly IRentalService _rentalService;
        private readonly IRuleService _ruleService;
        private readonly IFacilityService _facilityService;
        public Mutation(IResidenceService residenceService, IHostService hostService, IGuestService guestService, IRentalService rentalService, IFacilityService facilityService, IRuleService ruleService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
            _guestService = guestService;
            _rentalService = rentalService;
            _facilityService = facilityService;
            _ruleService = ruleService;
        }
        public async Task<Residence> CreateResidence(Residence residence)
        {
            return await _residenceService.CreateResidenceAsync(residence); 
        }

        public async Task<Host> UpdateHostStatus(Host host)
        {
            return await _hostService.UpdateHostStatusAsync(host);
        }

        public async Task<Guest> CreateGuest(Guest guest)
        {
            return await _guestService.CreateGuestAsync(guest); 
        }

        public async Task<Guest> UpdateGuestStatus(Guest guest)
        {
            return await _guestService.UpdateGuestStatus(guest);
        }

        public async Task<RentRequest> RentResidence(RentRequest request)
        {
            return await _rentalService.CreateRentRequest(request);
        }
        
        public async Task<Host> RegisterHost(Host host)
        {
            return await _hostService.RegisterHostAsync(host);
        }

        public async Task<Facility> CreateNewFacility(Facility facility)
        {
            return await _facilityService.CreateFacility(facility);
        }

        public async Task<Rule> CreateNewRule(Rule rule)
        {
            return await _ruleService.CreateRule(rule);
        }

        public async Task<RentRequest> UpdateRentRequestStatus(RentRequest request)
        {
            return await _rentalService.UpdateRentRequestStatusAsync(request);
        }
    }
}