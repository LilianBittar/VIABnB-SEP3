namespace SEP3T2GraphQL.Services.Validation.AdministrationValidation
{
    public interface IAdminValidation
    {
        bool IsValidId(int id);
        bool IsValidStatus(string status);
    }
}