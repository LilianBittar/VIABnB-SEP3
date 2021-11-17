// using System;
// using SEP3T2GraphQL.Models;
//
// namespace SEP3T2GraphQL.Services.Validation.GuestRegistrationRequestValidation.Impl
// {
//     public class GuestRegistrationRequestValidationImpl : IGuestRegistrationRequestValidation
//     {
//         public bool IsValidId(int id)
//         {
//             if (id < 0)
//             {
//                 throw new ArgumentException("Invalid ID");
//             }
//
//             return true;
//         }
//
//         public bool IsValidRequest(GuestRegistrationRequest request)
//         {
//             if (!request.Status.Equals(RequestStatus.Approved) ||
//                 !request.Status.Equals(RequestStatus.NotApproved) ||
//                 !request.Status.Equals(RequestStatus.NotAnswered) ||
//                 (request.StudentNumber < 0) || 
//                 request.Host == null ||
//                 request == null)
//             {
//                 throw new ArgumentException("Invalid request");
//             }
//
//             return true;
//         }
//     }
// }