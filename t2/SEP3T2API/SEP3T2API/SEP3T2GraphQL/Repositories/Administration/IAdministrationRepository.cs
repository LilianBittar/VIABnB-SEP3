using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

//Todo next sprint check about the IsValid methods. should be split or just change the approach. NOTE: change in t1 and t3 after
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
        /// Method that returns a host request based on the given parameter
        /// </summary>
        /// <param name="hostId">The Id of the host object that created the request</param>
        /// <returns>HostRegistrationRequest object</returns>
        Task<HostRegistrationRequest> GetHostRegistrationRequestByHostId(int hostId);
        /// <summary>
        /// Method that returns a host request based on the given parameter
        /// </summary>
        /// <param name="requestId">The Id of the desired host request</param>
        /// <returns>HostRegistrationRequest object</returns>
        Task<HostRegistrationRequest> GetHostRegistrationRequestById(int requestId);
        /// <summary>
        /// Method that validates the host profile using that host's Id and changing its status
        /// </summary>
        /// <param name="requestId">The desired host's Id</param>
        /// <param name="status">The new status of the host</param>
        /// <returns></returns>
        Task IsValidHost(int requestId, RequestStatus status);
        //The below code relevant for handling the GuestRegistrationRequest
        /// <summary>
        /// Method that returns a list of all guest requests in the system 
        /// </summary>
        /// <returns>List of all GuestRegistrationRequest objects in the system</returns>
        Task<IList<GuestRegistrationRequest>> GetAllGuestRegistrationRequests();
        /// <summary>
        /// Method that returns a guest request based on the given parameter
        /// </summary>
        /// <param name="hostId">The Id of the host object that created the request</param>
        /// <returns>GuestRegistrationRequest object</returns>
        Task<GuestRegistrationRequest> GetGuestRegistrationRequestByHostId(int hostId);
        /// <summary>
        /// Method that returns a guest request based on the given parameter
        /// </summary>
        /// <param name="requestId">The Id of the desired guest request</param>
        /// <returns>HostRegistrationRequest object</returns>
        Task<GuestRegistrationRequest> GetGuestRegistrationRequestById(int requestId);
        /// <summary>
        /// Method that validates the host profile using that host's Id and changing its status
        /// </summary>
        /// <param name="requestId">The desired guest's Id</param>
        /// <param name="status">The new status of the guest</param>
        /// <returns></returns>
        Task IsValidGuest(int requestId, RequestStatus status);
    }
}