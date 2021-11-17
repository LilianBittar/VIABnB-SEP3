using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.GuestRegistrationRequestValidation
{
    public interface IGuestRegistrationRequestValidation
    {
        bool IsValidId(int id);
        bool IsValidRequest(GuestRegistrationRequest request);
    }
}