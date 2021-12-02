using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.HostValidation
{
    public interface IHostValidation
    {
        Task<bool> IsValidEmail(string email);
        bool IsValidFirstname(string firstname);
        bool IsValidLastname(string lastname);
        bool IsValidPassword(string passWord);
        bool IsValidPhoneNumber(string phoneNumber);
        bool IsValidCprNumber(string cpr);
        Task<bool> IsValidHost(Host host);
    }
}