using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlResidenceService : IResidenceService
    {
        private const string Url = "https://localhost:5001/graphql";

        public async Task<Residence> GetResidenceAsync(int id)
        {
            var graphQlClient = new GraphQLHttpClient(Url, new NewtonsoftJsonSerializer());
            var residenceQuery = new GraphQLRequest()
            {
                Query = @"query{
  residence(id:1){
    id, 
    address{
      id,
      streetName,
      houseNumber,
      cityName,
      streetNumber,
      zipCode
    }, 
    description,
    type,
    averageRating,
    isAvailable,
    pricePerNight,
    rules{
      description
    },
    facilities{
      name
    }
  }
}
"
                // ,
                // Variables = new {residenceId = id}
            };
            var graphQlResponse = await graphQlClient.SendQueryAsync<Residence>(residenceQuery);
         
            return graphQlResponse.Data; 
        }

        public Task<Residence> CreateResidenceAsync(Residence residence)
        {
            throw new System.NotImplementedException();
        }
    }
}