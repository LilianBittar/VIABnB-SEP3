using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public partial class GraphQlGuestService : IGuestService
    {
        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            var query = new GqlQuery()
            {
                Query = @"query($guestId:Int!){
                              guestById(guestId:$guestId){
                                viaId
                                guestReviews{
                                  rating
                                  text
                                  createdDate
                                  guestId
                                  hostId
                                }
                                isApprovedGuest
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
                            }",
                Variables = new {guestId = id}
            };
            var response = await _client.PostQueryAsync<GuestByIdResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.Guest;
        }

        public async Task<Guest> GetGuestByEmailAsync(string email)
        {
            var guestQuery = new GqlQuery()
            {
                Query =
                    @"query($wantedGuestEmail:String){
                            guestByEmail(email:$wantedGuestEmail) {
                          viaId
                            guestReviews{
                              rating
                              text
                              createdDate
                              guestId
                              hostId
                            }
                            isApprovedGuest
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
                        }
                        ",
                Variables = new {wantedGuestEmail = email}
            };
            var response = await _client.PostQueryAsync<GuestByEmailResponseType>(guestQuery);
            HandleErrorResponse(response);
            return response.Data.Guest;
        }
        public async Task<IEnumerable<Guest>> GetAllNotApprovedGuestsAsync()
        {
            var guestQuery = new GqlQuery()
            {
                Query =
                    @"query {allNotApprovedGuest{viaId
                        guestReviews{
                          rating
                          text
                          createdDate
                          guestId
                          hostId
                        }
                        isApprovedGuest
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
                    }}"
            };
            var graphQlResponse =
                await _client.PostQueryAsync<GuestListResponse>(guestQuery);
            HandleErrorResponse(graphQlResponse);
            return graphQlResponse.Data.Guests;
        }

        public async Task<Host> UpdateGuestStatusAsync(Guest guest)
        {
            GqlQuery updateStatusMutation = new GqlQuery()
            {
                Query =
                    @"mutation($newGuest:GuestInput)
                        {updateGuestStatus(guest:$newGuest)
                        {viaId
                            guestReviews{
                              rating
                              text
                              createdDate
                              guestId
                              hostId
                            }
                            isApprovedGuest
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
                            profileImageUrl}}",
                Variables = new {newGuest = guest}
            };
            var response = await _client.PostQueryAsync<UpdateGuestMutationResponseType>(updateStatusMutation);
            HandleErrorResponse(response);
            return response.Data.UpdateGuest;
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