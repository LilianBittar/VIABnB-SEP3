using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQLClient.QueryResponses;
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
                Query = @"query($residenceId: int){
                          residence(id: $residenceId){
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
                Variables = new {residenceId = id}
            };
            var graphQlResponse = await client.PostQueryAsync<ResidenceQueryResponseType>(residenceQuery);
         
            System.Console.WriteLine($"{this} received: {graphQlResponse.Data.Residence.ToString()}");
            return graphQlResponse.Data.Residence; 
        }

        public async Task<List<Residence>> GetResidenceByHostId(int Id)
        {
            GqlClient client = new GqlClient(Url);
            var residenceQuery = new GqlQuery()
            {
                Query = @"query($hostId: int){
                          host(id: $hostId){
                            id,
                            firstName,
                            lastName,
                            phoneNumber,
                            email,
                            password
                            }
                          }
",
                Variables = new {hostId = Id}
            };
            var graphQlResponse = await client.PostQueryAsync<ResidenceListQueryResponseType>(residenceQuery);
            
            System.Console.WriteLine($"{this} received: {graphQlResponse.Data.Residences.ToString()}");
            return graphQlResponse.Data.Residences;
        }
        public async Task<Residence>  CreateResidenceAsync(Residence residence)
        {

            GqlClient client = new GqlClient(Url){EnableLogging=true};
            GqlQuery residenceMutation = new GqlQuery()
            {
                Query = @"mutation($residenceInput: ResidenceInput){createResidence(residence: $residenceInput){id,address{id, zipCode, streetName, houseNumber, cityName, streetNumber, zipCode},description,type,averageRating,isAvailable,pricePerNight,rules{id, description},facilities{id, name},imageUrl,}}",
                Variables= new {residenceInput = residence}
            };
            var mutationResponse = await client.PostQueryAsync<CreateResidenceMutationResponseType>(residenceMutation);
            if (mutationResponse.Errors != null)
            { 
                /* SAMPLE ERROR RESPONSE
                {"data":{"createResidence":null},
                "errors":[{"message":"Unexpected Execution Error",
                "locations":[{"line":1,"column":43}],"path":["createResidence"],
                "extensions":{"message":"Invalid residence!!",
                "stackTrace":"at SEP3T2GraphQL.Services.ResidenceServiceImpl.CreateResidenceAsync(Residence residence) in C:\\Users\\Shark\\Documents\\Coding\\SEP3\\VIABnB-SEP3\\t2\\SEP3T2API\\SEP3T2API\\SEP3T2GraphQL\\Services\\ResidenceServiceImpl.cs:line 53\r\n   at SEP3T2GraphQL.Graphql.Mutation.CreateResidence(Residence residence) in C:\\Users\\Shark\\Documents\\Coding\\SEP3\\VIABnB-SEP3\\t2\\SEP3T2API\\SEP3T2API\\SEP3T2GraphQL\\Graphql\\Mutation.cs:line 17\r\n   at HotChocolate.Resolvers.Expressions.ExpressionHelper.AwaitTaskHelper[T](Task`1 task)\r\n   at HotChocolate.Types.Helpers.FieldMiddlewareCompiler.<>c__DisplayClass9_0.<<CreateResolverMiddleware>b__0>d.MoveNext()\r\n--- End of stack trace from previous location ---\r\n  
 at HotChocolate.Execution.Processing.Tasks.ResolverTask.ExecuteResolverPipelineAsync(CancellationToken cancellationToken)\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.TryExecuteAsync(CancellationToken cancellationToken)"}}]}
                */
                System.Console.WriteLine($"/n {this} Inside error, throwing new Exception.... /n");
                // String manipulation to seperate the Error message from the sample error response. 
                throw new ArgumentException(JsonConvert.SerializeObject(mutationResponse.Errors).Split(",")[4].Split(":")[2]); 
            }
          
            System.Console.WriteLine($"{this} received: {mutationResponse.Data.CreateResidence}");

            return mutationResponse.Data.CreateResidence;
        }

     
    }
}
 