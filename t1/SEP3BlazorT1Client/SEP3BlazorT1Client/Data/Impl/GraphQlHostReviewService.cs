using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlHostReviewService : IHostReviewService

    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};
        
        
        public Task<HostReview> CreateGuestReviewAsync(HostReview hostReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<HostReview> UpdateGuestReviewAsync(HostReview hostReview)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id)
        {
            var query = new GqlQuery()
            {
                Query = @"query($hostId:Int!){
                              allHostReviewsByHostId(id:$hostId){
                                rating
                                text
                                viaId
                                createdDate
                                hostId
                              }
                            }",
                Variables = new {hostId = id}
            };
            var graphQlResponse =
                await _client.PostQueryAsync<AllHostReviewsByHostIdResponseType>(query);
            return graphQlResponse.Data.HostReviews;
        }
    }
}