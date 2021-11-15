using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;
using CatQL.GraphQL.Client;
using CatQLClient.QueryResponses;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;

namespace SEP3BlazorT1Client.Data.Impl
{
    //TODO: Maybe rename this service to UserService or RegistrationRequestService, since administration is maybe a bit vague? - Micmic
    public class GraphQlAdministrationService : IAdministrationService
    {
        private const string Url = "https://localhost:5001/graphql";
        private GqlClient client = new GqlClient(Url); 
        public async Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(GuestRegistrationRequest guestRegistrationRequest)
        {
            var createGuestRegistrationRequestQuery = new GqlQuery()
            {
                Query = @"mutation ($request: GuestRegistrationRequestInput) {
                          createGuestRegistrationRequest(guestRegistrationRequest: $request) {
                            id,
                            studentNumber,
                            host {
                              id,
                              firstName,
                              lastName,
                              isApprovedHost,
                              phoneNumber,
                              password,
                              hostReviews {
                                id,
                                rating,
                                text,
                                viaId
                              },
                              profileImageUrl
                            },
                            studentIdImage,
                            status
                          }
                        }
                        ",
                Variables = new {request = guestRegistrationRequest}
            };
            var response = await client.PostQueryAsync<GuestRegistrationRequestResponse>(createGuestRegistrationRequestQuery);

            if (response.Errors != null)
            {
                throw new Exception("Something went wrong, try again later..."); 
            }

            return response.Data.CreateGuestRegistrationRequest; 
        }

        public Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestRegistrationRequest> ApproveGuestRegistrationRequestAsync(int requestId)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestRegistrationRequest> RejectGuestRegistrationRequestAsync(int requestId)
        {
            throw new System.NotImplementedException();
        }
    }
}