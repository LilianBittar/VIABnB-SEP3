using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Administration
{
    public interface IAdministrationService
    {
        Task<Administrator> GetAdminByEmail(string email);
        Task<IEnumerable<Administrator>> GetAllAdmins();
        Task<Administrator> ValidateAdmin(string email, string password);
    }
}