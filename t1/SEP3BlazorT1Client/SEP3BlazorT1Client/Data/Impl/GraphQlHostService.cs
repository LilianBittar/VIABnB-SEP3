using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.HostResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlHostService : IHostService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new(Url) {EnableLogging = true};

        public async Task<Host> RegisterHostAsync(Host host)
        {
            var registerHostMutation = new GqlQuery()
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
            HandleErrorResponse(response);
            return response.Data.RegisterHost;
        }
        

        public async Task<Host> GetHostByEmailAsync(string email)
        {
            var query = new GqlQuery()
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
            HandleErrorResponse(response);
            return response.Data.Host;
        }

        public async Task<Host> GetHostByIdAsync(int id)
        {
            var query = new GqlQuery()
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
            HandleErrorResponse(response);
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
            var graphQlResponse =
                await client.PostQueryAsync<HostListResponseType>(hostQuery);
            HandleErrorResponse(graphQlResponse);
            return graphQlResponse.Data.Hosts;
        }

        public async Task<Host> UpdateHostStatusAsync(Host host)
        {
            var updateHostStatusMutation = new GqlQuery()
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
            var response = await _client.PostQueryAsync<UpdateHostMutationResponseType>(updateHostStatusMutation);
            HandleErrorResponse(response);
            return response.Data.updateHostStatus;
        }
        private static void HandleErrorResponse<T>(GqlRequestResponse<T> response)
        {
            if (response.Errors != null)
            {
                // String manipulation to seperate the Error message from the sample error response. 
                Console.WriteLine(JsonConvert.SerializeObject(response.Errors));
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors).Split(",")[4]
                    .Split(":")[2]);
            }
        }
    }
}