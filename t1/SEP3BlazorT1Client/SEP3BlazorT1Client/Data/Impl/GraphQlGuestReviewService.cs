using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestResponseTypes;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestReviewResponseType;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.HostReviewsResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlGuestReviewService : IGuestReviewService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};
        
        public async Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview)
        {
            GqlQuery createGuestReviewMutation = new GqlQuery()
            {
                Query =
                    @"mutation($newGuestReview:guestReview){
    createGuestReview(guestReview:$newGuestReview) {
                                rating
                                reviewText
                                guestId
                                hostId
                                createdDate
                              }
                             }",

                Variables = new {newGuestReview = guestReview}
            };
            var response = await _client.PostQueryAsync<CreateGuestReviewResponseType>(createGuestReviewMutation);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors));
            }

            return response.Data.GuestReview;
        }

        public async Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview)
        {
            GqlQuery updateGuestReviewMutation = new GqlQuery()
            {
                Query =
                    @"mutation($newGuestReview:guestReview){
    updateGuestReview(hostReview:$newHostReview) {
                                rating
                                reviewText
                                viaId
                                hostId
                                createdDate
                              }
                             }",

                Variables = new {newHostReview = guestReview}
            };
            var response = await _client.PostQueryAsync<UpdateGuestReviewResponseType>(updateGuestReviewMutation);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors));
            }

            return response.Data.GuestReview;
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id)
        {
            var query = new GqlQuery()
            {
                Query = @"query($guestId:Int!){
                              allGuestReviewsByHostId(id:$guestId){
                                rating
                                text
                                hostEmail
                                createdDate
                                guestId
                                hostId
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