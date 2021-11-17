// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using SEP3T2GraphQL.Models;
// using SEP3T2GraphQL.Repositories;
// using SEP3T2GraphQL.Services.Validation.HostRegistrationRequestValidation;
// using SEP3T2GraphQL.Services.Validation.HostRegistrationRequestValidation.Impl;
//
// namespace SEP3T2GraphQL.Services.Impl
// {
//     public class HostRegistrationRequestServiceImpl : IHostRegistrationRequestService
//     {
//         private IHostRegistrationRequestRepository hostRegistrationRequestRepository;
//         private IHostService hostService;
//         private IHostRegistrationRequestValidation validation;
//
//         public HostRegistrationRequestServiceImpl(IHostRegistrationRequestRepository hostRegistrationRequestRepository)
//         {
//             this.hostRegistrationRequestRepository = hostRegistrationRequestRepository;
//             validation = new HostRegistrationRequestValidationImpl();
//         }
//
//         public async Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequestsAsync()
//         {
//             return await hostRegistrationRequestRepository.GetAllHostRegistrationRequests();
//         }
//
//         public async Task<HostRegistrationRequest> GetHostRegistrationRequestByHostIdAsync(int hostId)
//         {
//             if (validation.IsValidId(hostId))
//             {
//                 return await hostRegistrationRequestRepository.GetHostRegistrationRequestByHostId(hostId);
//             }
//
//             throw new ArgumentException("Invalid ID");
//         }
//
//         public async Task<HostRegistrationRequest> GetHostRegistrationRequestByIdAsync(int requestId)
//         {
//             if (validation.IsValidId(requestId))
//             {
//                 return await hostRegistrationRequestRepository.GetHostRegistrationRequestById(requestId);
//             }
//
//             throw new ArgumentException("Invalid ID");
//         }
//
//         public async Task UpdateHostRegistrationRequestAsync(HostRegistrationRequest request)
//         {
//             if (validation.IsValidRequest(request))
//             {
//                 await hostRegistrationRequestRepository.UpdateHostRegistrationRequest(request);
//             }
//         }
//     }
// }