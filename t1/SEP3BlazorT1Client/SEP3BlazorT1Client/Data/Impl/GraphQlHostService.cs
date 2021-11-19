using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlHostService : IHostService
    {
        private const string Url = "https://localhost:5001/graphql";

        public Task<Host> RegisterHostAsync(Host host)
        {
            throw new System.NotImplementedException();
        }

        public Task<Host> ValidateHostAsync(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<Host> GetHostByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<Host> GetHostById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Host>> GetAllNotApprovedHostsAsync()
        {
            GqlClient client = new GqlClient(Url);
            var hostQuery = new GqlQuery()
            {
                Query = @"query{allNotApprovedHost{id, firstName,lastName,phoneNumber,email,password,hostReviews{id,rating,text,viaId}cpr,profileImageUrl,isApprovedHost}}"
            };
            var graphQLResponse = await client.PostQueryAsync<HostListResponseType>(hostQuery);
            return graphQLResponse.Data.Hosts;
        }

        public Task<Host> UpdateHostStatusAsync(Host host)
        {
            throw new System.NotImplementedException();
        }

        public Task<Host> UpdateHost(Host host)
        {
            throw new System.NotImplementedException();
        }
    }
}