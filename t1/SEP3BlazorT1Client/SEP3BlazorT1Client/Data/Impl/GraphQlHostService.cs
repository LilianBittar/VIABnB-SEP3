using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
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

        public async Task<IList<Host>> GetAllNotApprovedHostsAsync()
        {
            GqlClient client = new GqlClient(Url);
            var hostQuery = new GqlQuery()
            {
                Query = @"query{allNotApprovedHost{id, firstName,lastName,phoneNumber,email,password,hostReviews{id,rating,text,viaId},cpr,profileImageUrl,isApprovedHost}}",
            };
            GqlRequestResponse<HostListResponseType> graphQlResponse = await client.PostQueryAsync<HostListResponseType>(hostQuery);
            Console.WriteLine(JsonSerializer.Serialize(graphQlResponse));
            return graphQlResponse.Data.Hosts;
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