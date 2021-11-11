using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public class GuestRegistrationRequestServiceImpl : IGuestRegistrationRequestService
    {

        private IGuestRegistrationRequestRepository _guestRegistrationRequestRepository; 

        public GuestRegistrationRequestServiceImpl(IGuestRegistrationRequestRepository guestRegistrationRequestRepository)
        {
            _guestRegistrationRequestRepository = guestRegistrationRequestRepository; 
        }
        public Task<GuestRegistrationRequest> ApproveGusetRegistrationRequsetAsync(int requestId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(GuestRegistrationRequest guestRegistrationRequest)
        {
            ValidateGuestRegistrationRequest(guestRegistrationRequest);
            return await _guestRegistrationRequestRepository.CreateGuestRegistrationRequestAsync(guestRegistrationRequest); 
        }

        public Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestRegistrationRequest> RejectGusetRegistrationRequsetAsync(int requestId)
        {
            throw new System.NotImplementedException();
        }

        private void ValidateGuestRegistrationRequest(GuestRegistrationRequest guestRegistrationRequest)
        {
            if (guestRegistrationRequest == null)
            {
                throw new ArgumentException("Request cannot be null");
            }
            if (guestRegistrationRequest.StudentNumber < 0 || guestRegistrationRequest.ToString().Length < 6)
            {
                throw new ArgumentException("Student Number is invalid"); 
            }
            if (guestRegistrationRequest.StudentIdImage == null)
            {
                throw new ArgumentNullException("Image of Student ID is required");
            }
      
        }
    }
}