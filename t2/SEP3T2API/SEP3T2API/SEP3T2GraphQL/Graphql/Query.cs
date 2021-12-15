using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services;

namespace SEP3T2GraphQL.Graphql
{
    public class Query
    {
        private readonly IResidenceService _residenceService;
        private readonly IHostService _hostService;
        private readonly IGuestService _guestService;
        private readonly IRentalService _rentalService;
        private readonly IAdministrationService _administrationService;
        private readonly IFacilityService _facilityService;
        private readonly IRuleService _ruleService;
        private readonly IUserService _userService;
        private readonly IGuestReviewService _guestReviewService;
        private readonly IHostReviewService _hostReview;
        private readonly IResidenceReviewService _residenceReviewService;
        public Query(IResidenceService residenceService, IHostService hostService, 
            IGuestService guestService, IRentalService rentalService, 
            IAdministrationService administrationService, 
            IFacilityService facilityService, IRuleService ruleService, 
            IUserService userService, IHostReviewService hostReview,
            IGuestReviewService guestReviewService, IResidenceReviewService residenceReviewService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
            _guestService = guestService;
            _rentalService = rentalService;
            _administrationService = administrationService;
            _facilityService = facilityService;
            _ruleService = ruleService;
            _userService = userService;
            _hostReview = hostReview;
            _guestReviewService = guestReviewService;
            _residenceReviewService = residenceReviewService;
        }
        public async Task<Residence> GetResidence(int id)
        {
            return await _residenceService.GetResidenceByIdAsync(id); 
        }

        public async Task<IEnumerable<Host>> GetAllNotApprovedHost()
        {
            return await _hostService.GetAllNotApprovedHostsAsync();
        }

        public async Task<IEnumerable<Guest>> GetAllNotApprovedGuest()
        {
            return await _guestService.GetAllNotApprovedGuestsAsync();
        }
        
        public async Task<Host> GetHostById(int id)
        {
            return await _hostService.GetHostByIdAsync(id); 
        }

        public async Task<Host> ValidatehostLogin(string email, string password)
        {
            return await _hostService.ValidateHostAsync(email, password);
        }
        
        public async Task<Host> GetGuestByStudentNumber(int studentNumber)
        {
            return await _guestService.GetGuestByStudentNumberAsync(studentNumber); 
        }
        
        public async Task<Guest> ValidateGuestLogin(string email, string password)
        {
            return await _guestService.ValidateGuestAsync(email, password);

        }

        public async Task<Administrator> GetAdminByEmail(string email)
        {
            return await _administrationService.GetAdminByEmail(email);
        }

        public async Task<IEnumerable<Administrator>> GetAllAdmins()
        {
            return await _administrationService.GetAllAdmins();
        }

        public async Task<IEnumerable<Facility>> GetAllFacilities()
        {
            return await _facilityService.GetAllFacilitiesAsync();
        }

        public async Task<Facility> GetFacilityById(int id)
        {
            return await _facilityService.GetFacilityByIdAsync(id);
        }

        public async Task<IEnumerable<Rule>> GetAllRulesByResidenceId(int residenceId)
        {
            return await _ruleService.GetAllRulesByResidenceIdAsync(residenceId);
        }

        public async Task<Administrator> ValidateAdmin(string email, string password)
        {
            return await _administrationService.ValidateAdmin(email, password);
        }

        public async Task<IEnumerable<RentRequest>> GetAllRentRequestsByHostId(int hostId)
        {
            return await _rentalService.GetAllRentRequestsByHostIdAsync(hostId);
        }

        public async Task<IEnumerable<RentRequest>> GetAllNotAnsweredRentRequest(int hostId)
        {
            return await _rentalService.GetAllNotAnsweredRentRequestAsync(hostId);
        }

        public Task<RentRequest> GetRentRequestById(int id)
        {
            return _rentalService.GetRentRequestAsync(id);
        }

        public async Task<IList<Residence>> GetAvailableResidences()
        {
            return await _residenceService.GetAvailableResidencesAsync(); 
        }

        public async Task<IEnumerable<RentRequest>> RentRequestsByGuestId(int guestId)
        {
            return await _rentalService.GetRentRequestsByGuestIdAsync(guestId); 
        }

        public async Task<IList<Residence>> GetResidencesByHostId(int id)
        {
            return await _residenceService.GetAllRegisteredResidencesByHostIdAsync(id);
        }

        public async Task<Guest> GetGuestByEmail(string email)
        {
            return await _guestService.GetGuestByEmailAsync(email);
        }

        public async Task<Host> GetHostByEmail(string email)
        {
            return await _hostService.GetHostByEmailAsync(email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userService.GetUserByEmailAsync(email);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userService.GetAllUsersAsync();
        }

        public async Task<User> ValidateUser(string email, string password)
        {
            return await _userService.ValidateUserAsync(email, password);
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestId(int id)
        {
            return await _guestReviewService.GetAllGuestReviewsByHostIdAsync(id);
        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByHostId(int id)
        {
            return await _hostReview.GetAllHostReviewsByHostIdAsync(id);
        }
        
        public async Task<IEnumerable<ResidenceReview>> GetAllResidenceReviewsByResidenceId(int residenceId)
        {
            return await _residenceReviewService.GetAllResidenceReviewByResidenceIdAsync(residenceId);
        }

        public async Task<Guest> GetGuestById(int guestId)
        {
            return await _guestService.GetGuestByIdAsync(guestId);
        }
    }
}