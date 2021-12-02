using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Impl
{
    public class UserService : IUserService
    {
        public Task<User> ValidateUser(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}