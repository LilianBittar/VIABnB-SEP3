using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlUserService : IUserService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};
        
        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> ValidateUserAsync(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}