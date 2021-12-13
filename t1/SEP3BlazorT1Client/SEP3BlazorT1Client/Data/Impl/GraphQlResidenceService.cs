using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.ResidenceResponseTypes;
using SEP3BlazorT1Client.Models;
namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlResidenceService : IResidenceService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url);

        public async Task<Residence> GetResidenceByIdAsync(int id)
        {
            var residenceQuery = new GqlQuery()
            {
                Query = @"query($residenceId: Int!) {
                            residence(id: $residenceId) {
                              id
                              address{
                                id
                                streetName
                                houseNumber
                                streetNumber
                                city{
                                  id
                                  cityName
                                  zipCode
                                }
                              }
                              description
                              type
                              isAvailable
                              pricePerNight
                              rules{
                                description
                                residenceId
                              }
                              facilities{
                                id
                                name
                              }
                              imageUrl
                              availableFrom
                              availableTo
                              maxNumberOfGuests
                              host{
                                hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
                              }
                              residenceReviews{
                                rating
                                reviewText
                                guestViaId
                                createdDate
                              }
                            }
                          }
                          ",
                Variables = new {residenceId = id}
            };
            var graphQlResponse = await _client.PostQueryAsync<ResidenceQueryResponseType>(residenceQuery);
            HandleErrorResponse(graphQlResponse);
            return graphQlResponse.Data.Residence;
        }
        public async Task<IList<Residence>> GetResidencesByHostIdAsync(int Id)
        {
            var residenceQuery = new GqlQuery()
            {
                Query = @"query ($hostId:Int!) {
                       residencesByHostId(id: $hostId) {                   
                        id
                              address{
                                id
                                streetName
                                houseNumber
                                streetNumber
                                city{
                                  id
                                  cityName
                                  zipCode
                                }
                              }
                              description
                              type
                              isAvailable
                              pricePerNight
                              rules{
                                description
                                residenceId
                              }
                              facilities{
                                id
                                name
                              }
                              imageUrl
                              availableFrom
                              availableTo
                              maxNumberOfGuests
                              host{
                                hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
                              }
                              residenceReviews{
                                rating
                                reviewText
                                guestViaId
                                createdDate
                              }
                  }
                }
              ",
                Variables = new {hostId = Id}
            };
            var graphQlResponse = await _client.PostQueryAsync<ResidenceListQueryResponseType>(residenceQuery);
            HandleErrorResponse(graphQlResponse);
            return graphQlResponse.Data.Residences;
        }

        public async Task<IList<Residence>> GetAllAvailableResidencesAsync()
        {
            var query = new GqlQuery()
            {
                Query = @"query {
                          availableResidences {
                          id
                              address{
                                id
                                streetName
                                houseNumber
                                streetNumber
                                city{
                                  id
                                  cityName
                                  zipCode
                                }
                              }
                              description
                              type
                              isAvailable
                              pricePerNight
                              rules{
                                description
                                residenceId
                              }
                              facilities{
                                id
                                name
                              }
                              imageUrl
                              availableFrom
                              availableTo
                              maxNumberOfGuests
                              host{
                                hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
                              }
                              residenceReviews{
                                rating
                                reviewText
                                guestViaId
                                createdDate
                              }
                          }
                        }
                        "
            };
            var response = await _client.PostQueryAsync<AvailableResidencesQueryResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.AvailableResidences;
        }

        public async Task<Residence> UpdateResidenceAsync(Residence residence)
        {
            var mutation = new GqlQuery()
            {
                Query = @"mutation($newResidence:ResidenceInput){
                        updateResidence(residence:$newResidence){
                          id
                              address{
                                id
                                streetName
                                houseNumber
                                streetNumber
                                city{
                                  id
                                  cityName
                                  zipCode
                                }
                              }
                              description
                              type
                              isAvailable
                              pricePerNight
                              rules{
                                description
                                residenceId
                              }
                              facilities{
                                id
                                name
                              }
                              imageUrl
                              availableFrom
                              availableTo
                              maxNumberOfGuests
                              host{
                                hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
                              }
                              residenceReviews{
                                rating
                                reviewText
                                guestViaId
                                createdDate
                              }
                        }
                      }",
                Variables = new {newResidence = residence}
            };
            var response = await _client.PostQueryAsync<UpdateResidenceResponseType>(mutation);
            HandleErrorResponse(response);
            return response.Data.Residence;
        }

        public async Task<Residence> DeleteResidenceAsync(Residence residence)
        {
            var mutation = new GqlQuery()
            {
                Query = @"mutation($dResidence:ResidenceInput){
                        deleteResidence(residence:$dResidence){
                          id
                              address{
                                id
                                streetName
                                houseNumber
                                streetNumber
                                city{
                                  id
                                  cityName
                                  zipCode
                                }
                              }
                              description
                              type
                              isAvailable
                              pricePerNight
                              rules{
                                description
                                residenceId
                              }
                              facilities{
                                id
                                name
                              }
                              imageUrl
                              availableFrom
                              availableTo
                              maxNumberOfGuests
                              host{
                                hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
                              }
                              residenceReviews{
                                rating
                                reviewText
                                guestViaId
                                createdDate
                              }
                        }
                      }",
                Variables = new {dResidence = residence}
            };
            var response = await _client.PostQueryAsync<DeleteResidenceResponseType>(mutation);
            HandleErrorResponse(response);
            return response.Data.Residence;
        }

        public async Task<Residence> CreateResidenceAsync(Residence residence)
        {
            GqlClient client = new GqlClient(Url) {EnableLogging = true};
            GqlQuery residenceMutation = new GqlQuery()
            {
                Query =
                    @"mutation($residenceInput: ResidenceInput){createResidence(residence: $residenceInput){
                                 id
                              address{
                                id
                                streetName
                                houseNumber
                                streetNumber
                                city{
                                  id
                                  cityName
                                  zipCode
                                }
                              }
                              description
                              type
                              isAvailable
                              pricePerNight
                              rules{
                                description
                                residenceId
                              }
                              facilities{
                                id
                                name
                              }
                              imageUrl
                              availableFrom
                              availableTo
                              maxNumberOfGuests
                              host{
                                hostReviews{
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                cpr
                                isApprovedHost
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                                profileImageUrl
                              }
                              residenceReviews{
                                rating
                                reviewText
                                guestViaId
                                createdDate
                              }
                                  }
                                }",
                Variables = new {residenceInput = residence}
            };
            var mutationResponse = await client.PostQueryAsync<CreateResidenceMutationResponseType>(residenceMutation);
            HandleErrorResponse(mutationResponse);
            return mutationResponse.Data.CreateResidence;
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