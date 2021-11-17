// using System.Collections.Generic;
// using System.Threading.Tasks;
// using SEP3T2GraphQL.Models;
//
// namespace SEP3T2GraphQL.Services
// {
//     public interface IHostRegistrationRequestService
//     {
//         //The below code relevant for handling the HostRegistrationRequest
//         /// <summary>
//         /// Method that returns a list of all host requests in the system 
//         /// </summary>
//         /// <returns>List of all HostRegistrationRequest objects in the system</returns>
//         Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequestsAsync();
//         /// <summary>
//         /// Method that returns a host request based on the given parameter
//         /// </summary>
//         /// <param name="hostId">The Id of the host object that created the request</param>
//         /// <returns>HostRegistrationRequest object</returns>
//         Task<HostRegistrationRequest> GetHostRegistrationRequestByHostIdAsync(int hostId);
//         /// <summary>
//         /// Method that returns a host request based on the given parameter
//         /// </summary>
//         /// <param name="requestId">The Id of the desired host request</param>
//         /// <returns>HostRegistrationRequest object</returns>
//         Task<HostRegistrationRequest> GetHostRegistrationRequestByIdAsync(int requestId);
//         Task UpdateHostRegistrationRequestAsync(HostRegistrationRequest request); 
//     }
// }