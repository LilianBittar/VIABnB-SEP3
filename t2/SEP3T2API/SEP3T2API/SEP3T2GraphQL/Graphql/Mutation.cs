using System;
using System.Text.Json;
using System.Threading.Tasks;
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
        private readonly IGuestReviewService _guestReviewService;
        private readonly IHostReviewService _hostReview;
        private readonly IResidenceReviewService _residenceReviewService;
        private readonly IUserService _userService;

        public Mutation(IResidenceService residenceService, IHostService hostService, IGuestService guestService,
            IRentalService rentalService, IFacilityService facilityService, IRuleService ruleService,
            IGuestReviewService guestReviewService, IHostReviewService hostReviewService, IResidenceReviewService residenceReviewService, IUserService userService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
            _guestService = guestService;
            _rentalService = rentalService;
            _facilityService = facilityService;
            _ruleService = ruleService;
            _guestReviewService = guestReviewService;
            _hostReview = hostReviewService;
            _residenceReviewService = residenceReviewService;
            _userService = userService;
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
            return await _guestService.UpdateGuestStatusAsync(guest);
        }

        public async Task<RentRequest> RentResidence(RentRequest request)
        {
            return await _rentalService.CreateRentRequestAsync(request);
        }

        public async Task<Host> RegisterHost(Host host)
        {
            return await _hostService.RegisterHostAsync(host);
        }

        public async Task<Facility> CreateResidenceFacility(Facility facility, int residenceId)
        {
            return await _facilityService.CreateResidenceFacilityAsync(facility, residenceId);
        }

        public async Task<Rule> CreateNewResidenceRule(Rule rule)
        {
            return await _ruleService.CreateResidenceRuleAsync(rule);
        }

        public async Task<RentRequest> UpdateRentRequestStatus(RentRequest request)
        {
            return await _rentalService.UpdateRentRequestStatusAsync(request);
        }

        public async Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence)
        {
            return await _residenceService.UpdateResidenceAvailabilityAsync(residence);
        }

        public async Task<GuestReview> CreateGuestReview(GuestReview guestReview)
        {
            return await _guestReviewService.CreateGuestReviewAsync(guestReview);
        }

        public async Task<GuestReview> UpdateGuestReview(GuestReview guestReview)
        {
            return await _guestReviewService.UpdateGuestReviewAsync(guestReview);
        }

        public async Task<ResidenceReview> CreateResidenceReview(Residence residence, ResidenceReview residenceReview)
        {
            return await _residenceReviewService.CreateResidenceReviewAsync(residence, residenceReview); 
        }
        
        public async Task<HostReview> CreateHostReview(HostReview hostReview)
        {
            return await _hostReview.CreateHostReviewAsync(hostReview);
        }

        public async Task<HostReview> UpdateHostReview(HostReview hostReview)
        {
            return await _hostReview.UpdateHostReviewAsync(hostReview);
        }

        public async Task<Rule> UpdateResidenceRule(Rule rule, string description)
        {
            return await _ruleService.UpdateRuleAsync(rule, description);
        }

        public async Task<Residence> UpdateResidence(Residence residence)
        {
            return await _residenceService.UpdateResidenceAsync(residence);
        }

        public async Task<Rule> DeleteRule(Rule rule)
        {
            return await _ruleService.DeleteRuleAsync(rule);
        }

        public async Task<Facility> DeleteResidenceFacility(Facility facility, int residenceId)
        {
            return await _facilityService.DeleteResidenceFacilityAsync(facility, residenceId);
        }

        public async Task<Residence> DeleteResidence(Residence residence)
        {
            return await _residenceService.DeleteResidenceAsync(residence);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userService.UpdateUserAsync(user);
        }

        public async Task<User> DeleteUser(User user)
        {
            return await _userService.DeleteUserSync(user);
        }
    }
}