using System.Collections.Generic;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.HostValidation
{
    public interface IHostValidation
    {
        bool IsValidEmail(string email);
        bool IsValidFirstname(string firstname);
        bool IsValidLastname(string lastname);
        bool IsValidPassword(string password);
        bool IsValidPhoneNumber(string phenumber);
        bool IsValidHost(Host host);
        
    }
}