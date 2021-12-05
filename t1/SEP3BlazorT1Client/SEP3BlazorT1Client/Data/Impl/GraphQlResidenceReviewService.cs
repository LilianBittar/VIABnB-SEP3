using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlResidenceReviewService : IResidenceReviewService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};

        public Task<IEnumerable<ResidenceReview>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ResidenceReview>> GetAllByResidenceIdAsync(int residenceId)
        {
            var query = new GqlQuery()
            {
                Query = @"query(residenceId:Int!){
                              GetAllResidenceReviewsByResidenceId(id:residenceId){
                                rating
                                reviewText
                                guestViaId
                                createdDate
                              }
                            }",
                Variables = new {residenceId = residenceId}
            };
            var graphQlResponse =
                await _client.PostQueryAsync<ResidenceReviewsByResidenceIdResponseType>(query);
            return graphQlResponse.Data.ResidenceReviews;
        }

        public async Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview)
        {
            var query = new GqlQuery()
            {
                Query = @"mutation($targetResidence: ResidenceInput, $newReview: ResidenceReviewInput) {
                              createResidenceReview(
                                residence: $targetResidence
                                residenceReview: $newReview
                              ) {
                                rating
                                reviewText
                                guestViaId
                                createdDate
                              }
                            }
                            ",
                Variables = new {targetResidence = residence, newReview = residenceReview}
            };
            var response = await _client.PostQueryAsync<CreateResidenceReviewResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.ResidenceReview;
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