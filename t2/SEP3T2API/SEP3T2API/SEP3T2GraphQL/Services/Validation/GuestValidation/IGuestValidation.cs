using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.GuestValidation
{
    public interface IGuestValidation
    {
        bool IsValidStudentNumber(int studentNumber);
        bool IsValidPassword(string password);
        bool IsValidGuest(Guest guest);
    }
}