using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Administration;

namespace SEP3T2GraphQL.Graphql
{
    public class Query
    {
        private readonly IResidenceService _residenceService;
        private readonly IHostService _hostService;
        private readonly IGuestService _guestService;
        private readonly IRentalService _rentalService;
        private readonly IAdministrationService _administrationService;
        private IFacilityService _facilityService;
        private IRuleService _ruleService;
        public Query(IResidenceService residenceService, IHostService hostService, IGuestService guestService, IRentalService rentalService, IAdministrationService administrationService, IFacilityService facilityService, IRuleService ruleService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
            _guestService = guestService;
            _rentalService = rentalService;
            _administrationService = administrationService;
            _facilityService = facilityService;
            _ruleService = ruleService;
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
            return await _guestService.GetAllNotApprovedGuests();
        }
        
        public async Task<Host> GetHostById(int id)
        {
            return await _hostService.GetHostById(id); 
        }

        public async Task<Host> ValidatehostLogin(string email, string password)
        {
            return await _hostService.ValidateHostAsync(email, password);
        }
        
        public async Task<Host> GetGuestByStudentNumber(int studentNumber)
        {
            return await _guestService.GetGuestByStudentNumber(studentNumber); 
        }
        
        public async Task<Host> ValidateGuestLogin(int studentNumber, string password)
        {
            return await _guestService.ValidateGuestAsync(studentNumber, password);

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
            return await _facilityService.GetAllFacilities();
        }

        public async Task<Facility> GetFacilityById(int id)
        {
            return await _facilityService.GetFacilityById(id);
        }

        public async Task<IEnumerable<Rule>> GetAllRules()
        {
            return await _ruleService.GetAllRules();
        }

        public async Task<Administrator> ValidateAdmin(string email, string password)
        {
            return await _administrationService.ValidateAdmin(email, password);
        }

        public async Task<IEnumerable<RentRequest>> GetAllRentRequests()
        {
            return await _rentalService.GetAllRentRequestsAsync();
        }

        public Task<RentRequest> GetRentRequestById(int id)
        {
            return _rentalService.GetRentRequestAsync(id);
        }

        public async Task<IList<Residence>> GetAvailableResidences()
        {
            return await _residenceService.GetAvailableResidencesAsync(); 
        }
    }
}