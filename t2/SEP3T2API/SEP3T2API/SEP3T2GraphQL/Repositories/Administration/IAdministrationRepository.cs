using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Administration
{
    public interface IAdministrationRepository
    {
        Task<Administrator> GetAdminByEmail(string email);
        Task<IEnumerable<Administrator>> GetAllAdmins();
        Task<Administrator> ValidateAdmin(Administrator administrator);
    }
}