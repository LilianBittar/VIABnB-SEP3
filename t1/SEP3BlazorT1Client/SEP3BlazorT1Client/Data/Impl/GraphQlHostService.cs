using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.HostResponseTypes;
using SEP3BlazorT1Client.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlHostService : IHostService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new(Url) {EnableLogging = true};

        public async Task<Host> RegisterHostAsync(Host host)
        {
            GqlQuery registerHostMutation = new GqlQuery()
            {
                    Query = @"mutation($newHost: HostInput) 
                                {
                                  registerHost(host:$newHost){
                                  hostReviews {
                                    rating
                                    text
                                    guestId
                                    createdDate
                                    hostId
                                  }
                                  cpr
                                  isApprovedHost
                                  id
                                  email
                                  password
                                  firstName
                                  lastName
                                  phoneNumber
                                  profileImageUrl
                                }
                                }",
                Variables = new {newHost = host}
            };

            var response = await _client.PostQueryAsync<RegisterHostResponseType>(registerHostMutation);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors).Split(",")[4].Split(":")[2]);
            }

            return response.Data.RegisterHost;
        }
        

        public async Task<Host> GetHostByEmail(string email)
        {
            GqlQuery query = new()
            {
                Query = @"query($hostEmail:String) {
                                  hostByEmail(email:$hostEmail) {
                                    hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
                                  }
                                }
                            ",
                Variables = new {hostEmail = email}
            };
            var response = await _client.PostQueryAsync<HostByEmailResponseType>(query);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors));
            }
            return response.Data.Host;
        }

        public async Task<Host> GetHostById(int id)
        {
            GqlQuery query = new()
            {
                Query = @"query($hostId: Int!) {
                                hostById(id: $hostId) {
                                    hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
                                }
                            }
                            ",
                Variables = new {hostId = id}
            };
            var response = await _client.PostQueryAsync<HostByIdQueryResponseType>(query);
            return response.Data.HostById;
        }

        public async Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync()
        {
            GqlClient client = new GqlClient(Url);
            var hostQuery = new GqlQuery()
            {
                Query =
                    @"query{allNotApprovedHost{ hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl}}",
            };
            GqlRequestResponse<HostListResponseType> graphQlResponse =
                await client.PostQueryAsync<HostListResponseType>(hostQuery);
            return graphQlResponse.Data.Hosts;
        }

        public async Task<Host> UpdateHostStatusAsync(Host host)
        {
            GqlClient client = new GqlClient(Url);
            GqlQuery updateHostStatusMutation = new GqlQuery()
            {
                Query = @"mutation($newHost:HostInput){
                          updateHostStatus(host:$newHost){
                             hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
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