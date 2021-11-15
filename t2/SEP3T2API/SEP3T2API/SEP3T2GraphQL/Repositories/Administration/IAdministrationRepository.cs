using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Administration
{
    /// <summary>
    /// This interface is responsible to send and receive Guest and Host request from the data server side.
    ///  This repository interface is independent of the corresponding
    /// business logic interface to avoid rewriting the code in case of data server changes
    /// </summary>
    public interface IAdministrationRepository
    {
        //The below code relevant for handling the HostRegistrationRequest
        /// <summary>
        /// Method that returns a list of all host requests in the system 
        /// </summary>
        /// <returns>List of all HostRegistrationRequest objects in the system</returns>
        Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequests();
        /// <summary>
        /// Method that returns a host requests based on the given parameter
        /// </summary>
        /// <param name="hostId">The Id of the host object that created the request</param>
        /// <returns>HostRegistrationRequest objects </returns>
        Task<HostRegistrationRequest> GetHostRegistrationRequestByHostId(int hostId);
        Task<HostRegistrationRequest> GetHostRegistrationRequestById(int requestId);
        Task IsValidHost(int requestId, RequestStatus status);
        //The below code relevant for handling the GuestRegistrationRequest
        Task<IList<GuestRegistrationRequest>> GetAllGuestRegistrationRequests();
        Task<GuestRegistrationRequest> GetGuestRegistrationRequestByHostId(int hostId);
        Task<GuestRegistrationRequest> GetGuestRegistrationRequestById(int requestId);
        Task IsValidGuest(int requestId, RequestStatus status);
    }
}