using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.HostRegistrationRequestValidation
{
    public interface IHostRegistrationRequestValidation
    {
        bool IsValidId(int id);
        bool IsValidRequest(HostRegistrationRequest request);
    }
}