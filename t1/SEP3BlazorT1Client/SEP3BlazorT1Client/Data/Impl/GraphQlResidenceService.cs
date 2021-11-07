using System;
using System.Text.Json;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;

  /*
    Usage of client can be found at: https://github.com/michaelbui99/CatQL-GraphQL-Client
  */
namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlResidenceService : IResidenceService
    {
        private const string Url = "https://localhost:5001/graphql";

        public async Task<Residence> GetResidenceAsync(int id)
        {
            GqlClient client = new GqlClient(Url);
            var residenceQuery = new GqlQuery()
            {
                Query = @"query($id: int){
                          residence(id: $id){
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
",
                Variables = $"{{id:{id}}}" // {{ = {  in Interpolated strings. 
            };
            var graphQlResponse = await client.PostQueryAsync<ResidenceQueryResponseType>(residenceQuery);
         
            return graphQlResponse.Data.Residence; 
        }

        public async Task<Residence>  CreateResidenceAsync(Residence residence)
        {

            GqlClient client = new GqlClient(Url){EnableLogging=true};
            GqlQuery residenceMutation = new GqlQuery()
            {
                Query = @"mutation($residenceInput: ResidenceInput){createResidence(residence: $residenceInput){id,address{id, zipCode, streetName, houseNumber, cityName, streetNumber, zipCode},description,type,averageRating,isAvailable,pricePerNight,rules{id, description},facilities{id, name},imageUrl,}}",
                Variables= new {residenceInput = residence}
            };
            var mutationResponse = await client.PostQueryAsync<ResidenceQueryResponseType>(residenceMutation);
            return mutationResponse.Data.Residence;
        }
    }
}
 