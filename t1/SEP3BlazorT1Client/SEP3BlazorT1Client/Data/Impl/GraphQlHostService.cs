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

        public async Task<Host> ValidateHostAsync(string email, string password)
        {
            GqlClient client = new GqlClient(Url);
            var validateHostQuery = new GqlQuery()
            {
                Query = @"query($emailHost: String, $passwordHost: String) {
                          validatehostLogin(email: $emailHost, password: $passwordHost)
                           {id,
                           firstName,
                           lastName,
                           phoneNumber,
                           email,
                           password,
                           profileImageUrl,
                           cpr,
                           isApprovedHost}}",
                Variables = new {emailHost = email, passwordHost = password}
            };
            
            var graphQlResponse = await client.PostQueryAsync<HostResponseType>(validateHostQuery);
            Console.WriteLine(graphQlResponse.Data.ToString());
         
            System.Console.WriteLine($"{this} received: {graphQlResponse.Data.Host.ToString()}");
            return graphQlResponse.Data.Host; 
        }

        public Task<Host> GetHostByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<Host> GetHostById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync()
        {
            GqlClient client = new GqlClient(Url);
            var hostQuery = new GqlQuery()
            {
                Query = @"query{allNotApprovedHost{id, firstName,lastName,phoneNumber,email,password,hostReviews{id,rating,text,viaId},profileImageUrl,cpr,isApprovedHost}}",
            };
            GqlRequestResponse<HostListResponseType> graphQlResponse = await client.PostQueryAsync<HostListResponseType>(hostQuery);
            return graphQlResponse.Data.Hosts;
        }

        public async Task<Host> UpdateHostStatusAsync(Host host)
        {
            GqlClient client = new GqlClient(Url);
            GqlQuery updateHostStatusMutation = new GqlQuery()
            {
                Query = @"mutation($newHost:HostInput){
                          updateHostStatus(host:$newHost){
                            id,
                            firstName,
                            lastName,
                            phoneNumber,
                            email,
                            password,
                            hostReviews{
                              id,
                              viaId,
                              rating,
                              text
                            },
                            profileImageUrl,
                            cpr,
                            isApprovedHost
                          }
                        }",
                Variables = new {newHost = host}
            };
            var response = await client.PostQueryAsync<UpdateHostMutationResponseType>(updateHostStatusMutation);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors));
            }

            return response.Data.updateHostStatus;
        }

        public Task<Host> UpdateHost(Host host)
        {
            throw new System.NotImplementedException();
        }
    }
}