using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
    }
}