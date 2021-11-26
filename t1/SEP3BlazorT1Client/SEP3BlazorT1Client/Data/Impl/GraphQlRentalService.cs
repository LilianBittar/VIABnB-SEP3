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
        private readonly GqlClient _client = new GqlClient(Url);


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


        public Task<RentRequest> ApproveRentRequestAsync(RentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<RentRequest> RejectRentRequestAsync(RentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RentRequest>> GetAllRentRequestByResidenceId(int residenceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<RentRequest> GetRentRequestAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        private static void HandleErrorResponse(GqlRequestResponse<RentResidenceMutationResponseType> response)
        {
            if (response.Errors != null)
            {
                // String manipulation to seperate the Error message from the sample error response. 
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors).Split(",")[4]
                    .Split(":")[2]);
            }
        }
    }
}
