using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;
using CatQL.GraphQL.Client;
using CatQLClient.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;

namespace SEP3BlazorT1Client.Data.Impl
{
    //TODO: Maybe rename this service to UserService or RegistrationRequestService, since administration is maybe a bit vague? - Micmic
    public class GraphQlAdministrationService : IGuestRegistrationRequestService
    {
        private const string Url = "https://localhost:5001/graphql";
        private GqlClient client = new GqlClient(Url) {EnableLogging = true};

        public Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HostRegistrationRequest> GetHostRegistrationRequestsByHostIdAsync(int hostId)
        {
            throw new NotImplementedException();
        }

        public Task<HostRegistrationRequest> GetHostRegistrationRequestByIdAsync(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task IsValidHost(int requestId, RequestStatus status)
        {
            throw new NotImplementedException();
        }

        public async Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(
            GuestRegistrationRequest guestRegistrationRequest)
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
            try
            {
                var response =
                    await client.PostQueryAsync<GuestRegistrationRequestResponse>(createGuestRegistrationRequestQuery);
                if (response.Errors != null)
                {
                    Console.WriteLine($"{this} caught exception");
                    throw new ArgumentException(JsonConvert.SerializeObject(response.Errors).Split(",")[4].Split(":")[2]);
                }
                return response.Data.CreateGuestRegistrationRequest;

            }
            catch (Exception e)
            {
                Console.WriteLine($"{this} caught exception");
                throw new Exception("Something went wrong, try again later...");
            }
        }

        public Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateGuestRegistrationRequestAsync(GuestRegistrationRequest request)
        {
            throw new NotImplementedException();
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