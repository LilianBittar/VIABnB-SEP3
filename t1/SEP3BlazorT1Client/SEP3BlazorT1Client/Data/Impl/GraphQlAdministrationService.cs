using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlAdministrationService : IAdministrationService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new(Url) {EnableLogging = true};

        public Task<Administrator> GetAdminByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Administrator>> GetAllAdmins()
        {
            throw new System.NotImplementedException();
        }
    }
}