using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Administration.Impl
{
    public class AdministrationRepositoryImpl : IAdministrationRepository
    {
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;

        public AdministrationRepositoryImpl()
        {
            client = new HttpClient();
        }
        //Host

        public async Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequests()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/hostRequests");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<HostRegistrationRequest> requests = JsonSerializer.Deserialize<List<HostRegistrationRequest>>(result,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return requests;
        }

        public async Task<IList<HostRegistrationRequest>> GetHostRegistrationRequestsByHostId(int hostId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/hostRequests/{hostId}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<HostRegistrationRequest> requests = JsonSerializer.Deserialize<List<HostRegistrationRequest>>(result,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return requests;
        }

        public async Task<HostRegistrationRequest> GetHostRegistrationRequestsById(int requestId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/hostRequests/{requestId}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            HostRegistrationRequest request = JsonSerializer.Deserialize<HostRegistrationRequest>(result,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return request;
            
        }

        public async Task IsValidHost(int requestId, RequestStatus status)
        {
            string statusToUpdate = JsonSerializer.Serialize(status);
            HttpContent content = new StringContent(statusToUpdate,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage responseMessage = await client.PatchAsync(uri + $"/hostRequests/{requestId}", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }
        //Guest

        public async Task<IList<GuestRegistrationRequest>> GetAllGuestRegistrationRequests()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/guestRequests");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<GuestRegistrationRequest> requests = JsonSerializer.Deserialize<List<GuestRegistrationRequest>>(result,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return requests;
        }

        public async Task<IList<GuestRegistrationRequest>> GetGuestRegistrationRequestsByHostId(int hostId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/guestRequests/{hostId}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<GuestRegistrationRequest> requests = JsonSerializer.Deserialize<List<GuestRegistrationRequest>>(result,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return requests;
        }

        public async Task<GuestRegistrationRequest> GetGuestRegistrationRequestsById(int requestId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/guestRequests/{requestId}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            GuestRegistrationRequest request = JsonSerializer.Deserialize<GuestRegistrationRequest>(result,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return request;
        }

        public async Task IsValidGuest(int requestId, RequestStatus status)
        {
            string statusToUpdate = JsonSerializer.Serialize(status);
            HttpContent content = new StringContent(statusToUpdate,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage responseMessage = await client.PatchAsync(uri + $"/guestRequests/{requestId}", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }
    }
}