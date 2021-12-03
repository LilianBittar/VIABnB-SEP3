using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
                                  hostEmail
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
                                  guestViaId
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
                                  hostEmail
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
                                  guestViaId
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
                              guest {
                                viaId
                                guestReviews {
                                  id
                                  rating
                                  text
                                  hostEmail
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
                                  guestViaId
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
                            rentRequestById(int:requestId) 
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
                                  hostEmail
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
                                  guestViaId
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
                                  id
                                  rating
                                  text
                                  hostEmail
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
                                  guestViaId
                                }
                                
                              }
                        }
                       }
                        ",
            };
            var graphQlResponse =
                await _client.PostQueryAsync<AllNotAnsweredRentRequestResponseType>(allNotAnsweredRentRequestQuery);
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
                                  id
                                  rating
                                  text
                                  hostEmail
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
                                  guestViaId
                                }
                                
                              }
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