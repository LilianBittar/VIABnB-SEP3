using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.RentRequestResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlRentalService : IRentalService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};


        public async Task<RentRequest> CreateRentRequestAsync(RentRequest request)
        {
            var rentResidenceMutation = new GqlQuery()
            {
                Query = @"mutation($newRequest: RentRequestInput) {
                            rentResidence(request: $newRequest) {
                              id
                              startDate
                              endDate
                              numberOfGuests
                              status
                              guest {
                                viaId
                                guestReviews {
                                 rating
                              text
                              createdDate
                              guestId
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
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                profileImageUrl
                                cpr
                                isApprovedHost
                              }
                              residence {
                                averageRating
                                id
                                address {
                                  id
                                  streetName
                                  houseNumber
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
                                  residenceId
                                  description
                                }
                                facilities {
                                  id
                                  name
                                }
                                imageUrl
                                availableFrom
                                availableTo
                                maxNumberOfGuests
                                host{
                                  id
                                  firstName
                                  lastName
                                  phoneNumber
                                  email
                                  password
                                  hostReviews{
                                    rating
                                    text
                                    guestId
                                    createdDate
                                    hostId
                                  }
                                  profileImageUrl
                                  cpr
                                  isApprovedHost
                                }
                                residenceReviews {
                                  rating
                                  reviewText
                                  guestViaId
                                  createdDate
                                }
                                
                              }
                            requestCreationDate
                          }
                        }

                          ",
                Variables = new {newRequest = request}
            };
            var response = await _client.PostQueryAsync<RentResidenceMutationResponseType>(rentResidenceMutation);
            HandleErrorResponse(response);
            return response.Data.RentResidence;
        }


        public async Task<RentRequest> UpdateRentRequestAsync(RentRequest request)
        {
            var updatedRentRequest = new GqlQuery()
            {
                Query = @"mutation($updatedRentRequest:RentRequestInput) 
                          {
                            updateRentRequestStatus(request:$updatedRentRequest) 
                             {
                               id
                              startDate
                              endDate
                              numberOfGuests
                              status
                              guest {
                                viaId
                                guestReviews {
                                  rating
                              text
                              createdDate
                              guestId
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
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                profileImageUrl
                                cpr
                                isApprovedHost
                              }
                              residence {
                                averageRating
                                id
                                address {
                                  id
                                  streetName
                                  houseNumber
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
                                  residenceId
                                  description
                                }
                                facilities {
                                  id
                                  name
                                }
                                imageUrl
                                availableFrom
                                availableTo
                                maxNumberOfGuests
                                host{
                                  id
                                  firstName
                                  lastName
                                  phoneNumber
                                  email
                                  password
                                  hostReviews{
                                    rating
                                    text
                                    guestId
                                    createdDate
                                    hostId
                                  }
                                  profileImageUrl
                                  cpr
                                  isApprovedHost
                                }
                                residenceReviews {
                                  rating
                                  reviewText
                                  guestViaId
                                  createdDate
                                }
                                
                              }
                            requestCreationDate
                        }
                       }
                        ",
                Variables = new {updatedRentRequest = request}
            };
            var response = await _client.PostQueryAsync<UpdatedRentRequestResponseType>(updatedRentRequest);
            HandleErrorResponse(response);
            return response.Data.RentRequest;
        }

        public async Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync()
        {
            var allRents = new GqlQuery()
            {
                Query = @"query 
                          {
                          allRentRequests{
                           id
                              startDate
                              endDate
                              numberOfGuests
                              status
                              guest {
                                viaId
                                guestReviews {
                                  rating
                              text
                              createdDate
                              guestId
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
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                profileImageUrl
                                cpr
                                isApprovedHost
                              }
                              residence {
                                averageRating
                                id
                                address {
                                  id
                                  streetName
                                  houseNumber
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
                                  residenceId
                                  description
                                }
                                facilities {
                                  id
                                  name
                                }
                                imageUrl
                                availableFrom
                                availableTo
                                maxNumberOfGuests
                                host{
                                  id
                                  firstName
                                  lastName
                                  phoneNumber
                                  email
                                  password
                                  hostReviews{
                                    rating
                                    text
                                    guestId
                                    createdDate
                                    hostId
                                  }
                                  profileImageUrl
                                  cpr
                                  isApprovedHost
                                }
                                residenceReviews {
                                  rating
                                  reviewText
                                  guestViaId
                                  createdDate
                                }
                                
                              }
                            requestCreationDate
                        }
                       }
                        ",
            };
            var graphQlResponse =
                await _client.PostQueryAsync<RentRequestListResponseType>(allRents);
            HandleErrorResponse(graphQlResponse);
            return graphQlResponse.Data.RentRequests;
        }

        public async Task<IEnumerable<RentRequest>> GetAllNotAnsweredRentRequestAsync()
        {
            var allNotAnsweredRentRequestQuery = new GqlQuery()
            {
                Query = @"query
                          {
                            allNotAnsweredRentRequest
                             {
                              id
                              startDate
                              endDate
                              numberOfGuests
                              status
                              guest {
                                viaId
                                guestReviews {
                                  rating
                              text
                              createdDate
                              guestId
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
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                profileImageUrl
                                cpr
                                isApprovedHost
                              }
                              residence {
                                averageRating
                                id
                                address {
                                  id
                                  streetName
                                  houseNumber
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
                                  residenceId
                                  description
                                }
                                facilities {
                                  id
                                  name
                                }
                                imageUrl
                                availableFrom
                                availableTo
                                maxNumberOfGuests
                                host{
                                  id
                                  firstName
                                  lastName
                                  phoneNumber
                                  email
                                  password
                                  hostReviews{
                                    rating
                                    text
                                    guestId
                                    createdDate
                                    hostId
                                  }
                                  profileImageUrl
                                  cpr
                                  isApprovedHost
                                }
                                residenceReviews {
                                  rating
                                  reviewText
                                  guestViaId
                                  createdDate
                                }
                                
                              }
                            requestCreationDate
                        }
                       }
                        ",
            };
            var graphQlResponse =
                await _client.PostQueryAsync<AllNotAnsweredRentRequestResponseType>(allNotAnsweredRentRequestQuery);
            HandleErrorResponse(graphQlResponse);
            return graphQlResponse.Data.RentRequests;
        }

        public async Task<IEnumerable<RentRequest>> GetRentRequestsByGuestIdAsync(int guestId)
        {
            var query = new GqlQuery()
            {
                Query = @"query($id: Int!) {
                            rentRequestsByGuestId(guestId:$id) {
                              id
                              startDate
                              endDate
                              numberOfGuests
                              status
                              guest {
                                viaId
                                guestReviews {
                                  rating
                              text
                              createdDate
                              guestId
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
                                  rating
                                  text
                                  guestId
                                  createdDate
                                  hostId
                                }
                                profileImageUrl
                                cpr
                                isApprovedHost
                              }
                              residence {
                                averageRating
                                id
                                address {
                                  id
                                  streetName
                                  houseNumber
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
                                  residenceId
                                  description
                                }
                                facilities {
                                  id
                                  name
                                }
                                imageUrl
                                availableFrom
                                availableTo
                                maxNumberOfGuests
                                host{
                                  id
                                  firstName
                                  lastName
                                  phoneNumber
                                  email
                                  password
                                  hostReviews{
                                    rating
                                    text
                                    guestId
                                    createdDate
                                    hostId
                                  }
                                  profileImageUrl
                                  cpr
                                  isApprovedHost
                                }
                                residenceReviews {
                                  rating
                                  reviewText
                                  guestViaId
                                  createdDate
                                }
                                
                              }
                            requestCreationDate
                        }
                      }
                      ",
                Variables = new {id = guestId}
            };
            var response = await _client.PostQueryAsync<RentRequestsByGuestIdQueryResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.Requests;

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