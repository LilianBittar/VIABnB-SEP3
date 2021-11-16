using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class WebGuestRegistrationRequestRepository : IGuestRegistrationRequestRepository
    {
        
        private const string ApiUri = "http://localhost:8080/guestregistrationrequests";
        private HttpClient _client = new HttpClient();

        public async Task<GuestRegistrationRequest> CreateGuestRegistrationRequestAsync(
            GuestRegistrationRequest guestRegistrationRequest)
        {
            string requestAsJson = JsonSerializer.Serialize(guestRegistrationRequest,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            var payload = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(ApiUri, payload);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

            GuestRegistrationRequest createdRequest =
                JsonSerializer.Deserialize<GuestRegistrationRequest>(await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
            return createdRequest;
        }

        public Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequestsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateGuestRegistrationRequestAsync(GuestRegistrationRequest request)
        {
            string requestAsJson = JsonSerializer.Serialize(request);
            HttpContent content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response =
                await _client.PatchAsync(ApiUri + $"/{request.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        /*public Task<GuestRegistrationRequest> ApproveGuestRegistrationRequestAsync(int requestId)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestRegistrationRequest> RejectGuestRegistrationRequestAsync(int requestId)
        {
            throw new System.NotImplementedException();
        }
        */
    }
}