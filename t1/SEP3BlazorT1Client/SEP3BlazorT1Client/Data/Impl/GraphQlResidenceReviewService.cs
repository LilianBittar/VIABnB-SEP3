using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
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
        }
    }