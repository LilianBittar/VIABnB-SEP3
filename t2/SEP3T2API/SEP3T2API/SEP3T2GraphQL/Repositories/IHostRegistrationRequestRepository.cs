using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IHostRegistrationRequestRepository
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
        Task UpdateHostRegistrationRequest(HostRegistrationRequest request); 
        
    }
}