using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
                Query = @"query{allNotApprovedHost{id, firstName,lastName,phoneNumber,email,password,hostReviews{id,rating,text,viaId},profileImageUrl,cpr,isApprovedHost}}",
            };
            GqlRequestResponse<HostListResponseType> graphQlResponse = await client.PostQueryAsync<HostListResponseType>(hostQuery);
            Console.WriteLine(JsonSerializer.Serialize(graphQlResponse));
            return graphQlResponse.Data.Hosts;
        }

        public async Task<Host> UpdateHostStatusAsync(Host host)
        {
            GqlClient client = new GqlClient(Url) {EnableLogging = true};
            GqlQuery hostMutation = new GqlQuery()
            {
                Query =
                    "@mutation($hostInput: HostInput){updateHostStatus(host: $hostInput){id, firstName,lastName,phoneNumber,email,password,hostReviews{id,rating,text,viaId},profileImageUrl,cpr,isApprovedHost}}",
                Variables = new {hostInput = host}
            };
            var response = await client.PostQueryAsync<UpdateHostMutationResponseType>(hostMutation);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors).Split(",")[4].Split(":")[2]);
            }

            return response.Data.UpdateHost;
        }

        public Task<Host> UpdateHost(Host host)
        {
            throw new System.NotImplementedException();
        }
    }
}