using System;
using System.Text.Json;
using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
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

        public Mutation(IResidenceService residenceService, IHostService hostService, IGuestService guestService,
            IRentalService rentalService, IFacilityService facilityService, IRuleService ruleService,
            IGuestReviewService guestReviewService, IHostReviewService hostReviewService, IResidenceReviewService residenceReviewService)
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
            Console.WriteLine("in mutation");
            Console.WriteLine(JsonSerializer.Serialize(host));
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

        public async Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence)
        {
            return await _residenceService.UpdateResidenceAvailabilityAsync(residence);
        }

        public async Task<GuestReview> CreateGuestReview(GuestReview guestReview)
        {
            throw new NotImplementedException();
        }

        public async Task<GuestReview> UpdaeGuestReview(GuestReview guestReview)
        {
            throw new NotImplementedException();
        }

        public async Task<ResidenceReview> CreateResidenceReview(Residence residence, ResidenceReview residenceReview)
        {
            return await _residenceReviewService.CreateAsync(residence, residenceReview); 
        }
        
        public async Task<HostReview> CreateHostReview(HostReview hostReview)
        {
           return await _hostReview.CreateHostReviewAsync(hostReview);
        }

        public async Task<HostReview> UpdateHostReview(HostReview hostReview)
        {
            return await _hostReview.UpdateHostReviewAsync(hostReview);
        }

    }
}