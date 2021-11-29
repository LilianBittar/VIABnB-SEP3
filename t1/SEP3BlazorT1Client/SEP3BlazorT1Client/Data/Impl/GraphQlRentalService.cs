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
    public class GraphQlRentalService : IRentalService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};


        public async Task<RentRequest> CreateRentRequest(RentRequest request)
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
                              }
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
                              }
                        }
                       }
                        ",
                Variables = new {updatedRentRequest = request}
            };
            var response = await _client.PostQueryAsync<UpdatedRentRequestResponseType>(updatedRentRequest);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors));
            }

            return response.Data.RentRequest; 
        }

        public async Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync()
        {
            var allRents = new GqlQuery()
            {
                Query = @"query 
                          {
                            allRentRequests 
                             {
                               id
                               startDate
                               endDate
                               numberOfGuests
                               status
                               guest 
                                {
                                  viaId
                                  guestReviews 
                                    {
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
                                 hostReviews 
                                  {
                                     id
                                     viaId
                                     rating
                                     text
                                  }
                                 profileImageUrl
                                 cpr
                                 isApprovedHost
                               }
                             residence 
                              {
                                 id
                                 address 
                                  {
                                    id
                                    streetName
                                    houseNumber
                                    streetNumber
                                    city 
                                      {
                                        id
                                        cityName
                                        zipCode
                                      }
                                   }
                            description
                            type
                            averageRating
                            isAvailable
                            pricePerNight
                            rules 
                              {
                                residenceId
                                description
                              }
                            facilities 
                              {
                                id
                                name
                              }
                          }
                        }
                       }
                        ",
            };
            var graphQlResponse =
                await _client.PostQueryAsync<RentRequestListResponseType>(allRents);
            return graphQlResponse.Data.RentRequests;
        }

        public Task<IEnumerable<RentRequest>> GetAllRentRequestByResidenceId(int residenceId)
        {
            throw new NotImplementedException();
        }

        public async Task<RentRequest> GetRentRequestAsync(int id)
        {
            var getRentRequest = new GqlQuery()
            {
                Query = @"query($requestId:int) 
                          {
                            allRentRequests(int:requestId) 
                             {
                               id
                               startDate
                               endDate
                               numberOfGuests
                               status
                               guest 
                                {
                                  viaId
                                  guestReviews 
                                    {
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
                                 hostReviews 
                                  {
                                     id
                                     viaId
                                     rating
                                     text
                                  }
                                 profileImageUrl
                                 cpr
                                 isApprovedHost
                               }
                             residence 
                              {
                                 id
                                 address 
                                  {
                                    id
                                    streetName
                                    houseNumber
                                    streetNumber
                                    city 
                                      {
                                        id
                                        cityName
                                        zipCode
                                      }
                                   }
                            description
                            type
                            averageRating
                            isAvailable
                            pricePerNight
                            rules 
                              {
                                residenceId
                                description
                              }
                            facilities 
                              {
                                id
                                name
                              }
                          }
                        }
                       }
                        ",
                Variables = new {requestId = id}
            };
            var response = await _client.PostQueryAsync<RentRequestIdResponseType>(getRentRequest);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors));
            }

            return response.Data.RentRequest; 
        }
        private static void HandleErrorResponse(GqlRequestResponse<RentResidenceMutationResponseType> response)
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