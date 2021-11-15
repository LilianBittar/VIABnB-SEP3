using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    /// <summary>
    /// Business logic related to Guest Registration Request are contained in this service.
    /// This service makes use of an GuestRegistrationRequestRepository, which is responsible for making
    /// contact to the Database Server.
    /// This separation of components are done such that the Database servers communication paradigm can change without
    /// having to rewrite the business logic in another Service implementation. 
    /// </summary>
    public interface IGuestRegistrationRequestService
    {
        /// <summary>
        /// Creates a new Guest Registration Request, that an admin of the system can choose to approve/reject.
        /// An guest registration request can only be created, if the Host is approved.
        /// Method is to be used asynchronously.  
        /// </summary>
        /// <param name="guestRegistrationRequest"></param>
        /// <exception cref="ArgumentException">Exception is thrown if method param is null</exception>
        /// <exception cref="ArgumentException">Exception is thrown if student number is invalid, i.e. not 6 digits, is negative number or contains non-digit characters </exception>
        /// <exception cref="ArgumentException">Exception is thrown if studentIdImage is null</exception>
        /// <exception cref="ArgumentException">Exception is thrown if Host is not approved </exception>
        /// <returns>The newly created GuestRegistrationRequest as task</returns>
        Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(
            GuestRegistrationRequest guestRegistrationRequest);

        Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync();
        Task<GuestRegistrationRequest> ApproveGuestRegistrationRequestAsync(int requestId);
        Task<GuestRegistrationRequest> RejectGuestRegistrationRequestAsync(int requestId);
    }
}