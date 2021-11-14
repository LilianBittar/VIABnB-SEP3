using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories.Administration;
using SEP3T2GraphQL.Services.Validation.AdministrationValidation;
using SEP3T2GraphQL.Services.Validation.AdministrationValidation.Impl;

namespace SEP3T2GraphQL.Services.Administration.Impl
{
    public class AdministrationServiceImpl : IAdministrationService
    {
        private IAdministrationRepository _administrationRepository;
        private IAdminValidation _adminValidation;

        public AdministrationServiceImpl(IAdministrationRepository administrationRepository)
        {
            _administrationRepository = administrationRepository;
            _adminValidation = new AdminValidationImpl();
        }

        //Host
        public async Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequests()
        {
            return await _administrationRepository.GetAllHostRegistrationRequests();
        }

        public async Task<IList<HostRegistrationRequest>> GetHostRegistrationRequestsByHostId(int hostId)
        {
            if (_adminValidation.IsValidId(hostId))
            {
                return await _administrationRepository.GetHostRegistrationRequestsByHostId(hostId);
            }

            throw new ArgumentException("Invalid Host ID");
        }

        public async Task<HostRegistrationRequest> GetHostRegistrationRequestsById(int requestId)
        {
            if (_adminValidation.IsValidId(requestId))
            {
                return await _administrationRepository.GetHostRegistrationRequestsById(requestId);
            }

            throw new ArgumentException("Invalid Request ID");
        }

        public async Task IsValidHost(int requestId, RequestStatus status)
        {
            if (_adminValidation.IsValidId(requestId) && _adminValidation.IsValidStatus(status.ToString()))
            {
                await _administrationRepository.IsValidHost(requestId, status);
            }

            throw new ArgumentException("Invalid Status or Request ID");
        }
        
        //Guest
        public async Task<IList<GuestRegistrationRequest>> GetAllGuestRegistrationRequests()
        {
            return await _administrationRepository.GetAllGuestRegistrationRequests();
        }

        public async Task<IList<GuestRegistrationRequest>> GetGuestRegistrationRequestsByHostId(int hostId)
        {
            if (_adminValidation.IsValidId(hostId))
            {
                return await _administrationRepository.GetGuestRegistrationRequestsByHostId(hostId);
            }

            throw new ArgumentException("Invalid Host ID");
        }

        public async Task<GuestRegistrationRequest> GetGuestRegistrationRequestsById(int requestId)
        {
            if (_adminValidation.IsValidId(requestId))
            {
                return await _administrationRepository.GetGuestRegistrationRequestsById(requestId);
            }

            throw new ArgumentException("Invalid Request ID");
        }

        public async Task IsValidGuest(int requestId, RequestStatus status)
        {
            if (_adminValidation.IsValidId(requestId) && _adminValidation.IsValidStatus(status.ToString()))
            {
                await _administrationRepository.IsValidGuest(requestId, status);
            }

            throw new ArgumentException("Invalid Status or Request ID");
        }
    }
}