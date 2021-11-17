// using System;
// using System.Linq;
// using SEP3T2GraphQL.Models;
//
// namespace SEP3T2GraphQL.Services.Validation.HostRegistrationRequestValidation.Impl
// {
//     public class HostRegistrationRequestValidationImpl : IHostRegistrationRequestValidation
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
//         public bool IsValidRequest(HostRegistrationRequest request)
//         {
//             if (!request.Status.Equals(RequestStatus.Approved) ||
//                 !request.Status.Equals(RequestStatus.NotApproved) ||
//                 !request.Status.Equals(RequestStatus.NotAnswered) ||
//                 (request.CprNumber.Length != 10) || 
//                 !IsNumbersOnly(request.CprNumber) ||
//                 request == null)
//             {
//                 throw new ArgumentException("Invalid request");
//             }
//
//             return true;
//         }
//
//         private bool IsNumbersOnly(string arg)
//         {
//             if (arg.All(char.IsNumber))
//             {
//                 return true;
//             }
//             throw new ArgumentException($"Invalid string: {arg}");
//
//         }
//     }
// }