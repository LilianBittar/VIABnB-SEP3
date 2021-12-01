using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
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
        // TODO: Refactor methods to use the same GqlClient instance.  
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url);

        public async Task<Residence> GetResidenceAsync(int id)
        {
            GqlClient client = new GqlClient(Url);
            var residenceQuery = new GqlQuery()
            {
                Query = @"query ($residenceId:Int!){
  residence(id:$residenceId) {
    id
    address {
      id
      streetName
      streetNumber
      city {
        id
        cityName
        zipCode
      }
    }
    description
    type
    isAvailable
    pricePerNight
    rules {
      description
      residenceId
    }
    facilities {
      id
      name
    }
    availableFrom
    availableTo
    maxNumberOfGuests
    host {
      id
      firstName
      lastName
      phoneNumber
      email
      password
      hostReviews {
        id
        rating
        text
        viaId
      }
      profileImageUrl
      cpr
      isApprovedHost
    }
    residenceReviews {
      rating
      reviewText
      guest {
        viaId
        guestReviews {
          id
          rating
          text
          hostId
        }
        isApprovedGuest
        id
        firstName
        lastName
        phoneNumber
        email
        password
        hostReviews{id,rating,text,viaId}
        profileImageUrl
        cpr
        isApprovedHost
      }
    }
  }
}
",
                Variables = new {residenceId = id}
            };
            var graphQlResponse = await client.PostQueryAsync<ResidenceQueryResponseType>(residenceQuery);
            if (graphQlResponse.Errors != null)
            {
                throw new ArgumentException(
                    JsonConvert.SerializeObject(graphQlResponse.Errors).Split(",")[4].Split(":")[2]);
            }

            System.Console.WriteLine($"{this} received: {graphQlResponse.Data.Residence.ToString()}");
            return graphQlResponse.Data.Residence;
        }

        public Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Residence>> GetResidencesByHostIdAsync(int Id)
        {
            var residenceQuery = new GqlQuery()
            {
                Query = @"query ($hostId:Int!) {
                       residencesByHostId(id: $hostId) {
                      
    id
    address {
      id
      streetName
      streetNumber
      city {
        id
        cityName
        zipCode
      }
    }
    description
    type
    isAvailable
    pricePerNight
    imageUrl
    rules {
      description
      residenceId
    }
    facilities {
      id
      name
    }
    availableFrom
    availableTo
    maxNumberOfGuests
    host {
      id
      firstName
      lastName
      phoneNumber
      email
      password
      hostReviews {
        id
        rating
        text
        viaId
      }
      profileImageUrl
      cpr
      isApprovedHost
    }
    residenceReviews {
      rating
      reviewText
      guest {
        viaId
        guestReviews {
          id
          rating
          text
          hostId
        }
        isApprovedGuest
        id
        firstName
        lastName
        phoneNumber
        email
        password
        hostReviews {
          id
          rating
          text
          viaId
        }
        profileImageUrl
        cpr
        isApprovedHost
      }
    }
                  }
                }
              ",
                Variables = new {hostId = Id}
            };
            var graphQlResponse = await _client.PostQueryAsync<ResidenceListQueryResponseType>(residenceQuery);
            Console.WriteLine("hello");
            System.Console.WriteLine(graphQlResponse.Data);
            Console.WriteLine($"{this} received: {graphQlResponse.Data.Residences.ToString()}");
            return graphQlResponse.Data.Residences;
        }

        public async Task<IList<Residence>> GetAllAvailableResidencesAsync()
        {
            var query = new GqlQuery()
            {
                Query = @"query {
                          availableResidences {
                            id
                            address {
                              id
                              streetName
                              streetNumb
                              city {
                                id
                                cityName
                                zipCode
                              }
                            }
                            description
                            type
                            isAvailable
                            pricePerNight
                            rules {
                              description
                              residenceId
                            }
                            facilities {
                              id
                              name
                            }
                            availableFrom
                            availableTo
                            maxNumberOfGuests
                            host {
                              id
                              firstName
                              lastName
                              phoneNumber
                              email
                              password
                              hostReviews {
                                id
                                rating
                                text
                                viaId
                              }
                              profileImageUrl
                              cpr
                              isApprovedHost
                            }
                            residenceReviews {
                              rating
                              reviewText
                              guest {
                                viaId
                                guestReviews {
                                  id
                                  rating
                                  text
                                  hostId
                                }
                                isApprovedGuest
                                id
                                firstName
                                lastName
                                phoneNumber
                                email
                                password
                                hostReviews{id,rating,text,viaId}
                                profileImageUrl
                                cpr
                                isApprovedHost
                              }
                            }
                          }
                        }
                        "
            };
            var response = await _client.PostQueryAsync<AvailableResidencesQueryResponseType>(query);
            System.Console.WriteLine(response.Errors.ToString());
            System.Console.WriteLine($"{this} received: {response.Data.AvailableResidences.ToString()}");
            return response.Data.AvailableResidences;
        }

        public async Task<Residence> CreateResidenceAsync(Residence residence)
        {
            GqlClient client = new GqlClient(Url) {EnableLogging = true};
            GqlQuery residenceMutation = new GqlQuery()
            {
                Query =
                    @"mutation($residenceInput: ResidenceInput){createResidence(residence: $residenceInput){id,address{id, zipCode, streetName, houseNumber, streetNumber, City{id, cityName, zipCode}},description,type,isAvailable,pricePerNight,rules{description},facilities{id, name},imageUrl, residenceReviews{rating,reviewText,guest{viaId,guestReviews{id,rating,text,hostId},isApprovedGuest,id, firstName,lastName,phoneNumber,email,password,hostReviews{id,rating,text,viaId},profileImageUrl,cpr,isApprovedHost}}}}",
                Variables = new {residenceInput = residence}
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
                throw new ArgumentException(JsonConvert.SerializeObject(mutationResponse.Errors).Split(",")[4]
                    .Split(":")[2]);
            }

            System.Console.WriteLine($"{this} received: {mutationResponse.Data.CreateResidence}");

            return mutationResponse.Data.CreateResidence;
        }
    }
}