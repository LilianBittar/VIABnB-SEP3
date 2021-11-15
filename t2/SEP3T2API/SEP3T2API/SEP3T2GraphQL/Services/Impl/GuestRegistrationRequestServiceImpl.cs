using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public class GuestRegistrationRequestServiceImpl : IGuestRegistrationRequestService
    {
        private IGuestRegistrationRequestRepository _guestRegistrationRequestRepository;

        public GuestRegistrationRequestServiceImpl(
            IGuestRegistrationRequestRepository guestRegistrationRequestRepository)
        {
            _guestRegistrationRequestRepository = guestRegistrationRequestRepository;
        }

        public async Task<GuestRegistrationRequest> ApproveGuestRegistrationRequestAsync(int requestId)
        {
            if (requestId <= 0)
            {
                throw new ArgumentException("Invalid requestID");
            }
            
            return await _guestRegistrationRequestRepository.ApproveGuestRegistrationRequestAsync(requestId);
        }

        public async Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(
            GuestRegistrationRequest guestRegistrationRequest)
        {
            ValidateGuestRegistrationRequest(guestRegistrationRequest);
            return await _guestRegistrationRequestRepository.CreateGuestRegistrationRequestAsync(
                guestRegistrationRequest);
        }

        public async Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync()
        {
            return await _guestRegistrationRequestRepository.GetAllGuestRegistrationRequestsAsync();
        }

        public async Task<GuestRegistrationRequest> RejectGuestRegistrationRequestAsync(int requestId)
        {
            if (requestId <= 0)
            {
                throw new ArgumentException("Invalid requestID");
            }

            return await _guestRegistrationRequestRepository.RejectGuestRegistrationRequestAsync(requestId);
        }

        private void ValidateGuestRegistrationRequest(GuestRegistrationRequest guestRegistrationRequest)
        {
            if (guestRegistrationRequest == null)
            {
                throw new ArgumentException("Request cannot be null");
            }

            if (guestRegistrationRequest.StudentNumber <= 0 || guestRegistrationRequest.ToString().Length != 6  )
            {
                throw new ArgumentException("Student Number is invalid");
            }

            if (guestRegistrationRequest.StudentIdImage == null)
            {
                throw new ArgumentException("Image of Student Id is required");
            }

            if (!guestRegistrationRequest.Host.IsApprovedHost)
            {
                throw new ArgumentException("Host must be approved");
            }

        }
    }
}