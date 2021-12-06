using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlGuestReviewService : IGuestReviewService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};
        
        public Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id)
        {
            var query = new GqlQuery()
            {
                Query = @"query($guestId:Int!){
                              allGuestReviewsByGuestId(id:$guestId){
                                rating
                                text
                                hostEmail
                                createdDate
                              }
                            }",
                Variables = new {guestId = id}
            };
            var graphQlResponse =
                await _client.PostQueryAsync<AllGuestReviewsByGuestIdResponseType>(query);
            return graphQlResponse.Data.GuestReviews;
        }
    }
}