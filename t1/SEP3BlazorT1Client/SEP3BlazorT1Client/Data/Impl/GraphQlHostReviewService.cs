using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.HostReviewsResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlHostReviewService : IHostReviewService

    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};
        
        
        public async Task<HostReview> CreateHostReviewAsync(HostReview hostReview)
        {
            var query = new GqlQuery()
            {
                Query = @"mutation($newHostReview: HostReviewInput) {
                              createHostReview(hostReview: $newHostReview) {
                                rating
                                text
                                guestId
                                createdDate
                                hostId
                              }
                            }
                            ",
                Variables = new {newHostReview = hostReview}
            };
            var response = await _client.PostQueryAsync<CreateHostReviewResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.HostReview;
        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id)
        {
            var query = new GqlQuery()
            {
                Query = @"query($hostId: Int!) {
                              allHostReviewsByHostId(id: $hostId) {
                                rating
                                text
                                guestId
                                createdDate
                                hostId
                              }
                            }
                            ",
                Variables = new {hostId = id}
            };
            var graphQlResponse =
                await _client.PostQueryAsync<AllHostReviewsByHostIdResponseType>(query);
            HandleErrorResponse(graphQlResponse);
            return graphQlResponse.Data.HostReviews;
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