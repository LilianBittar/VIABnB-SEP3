using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class RentRequestRepository : IRentRequestRepository
    {
        private const string Url = "http://localhost:8080/rentrequests";
        private readonly HttpClient _client = new HttpClient();

        public async Task<RentRequest> CreateAsync(RentRequest request)
        {
            var requestAsJson = JsonSerializer.Serialize(request, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            StringContent payload = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(Url, payload);

            await HandleErrorResponse(response);
            var createdRentRequest =
                JsonSerializer.Deserialize<RentRequest>(await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
            return createdRentRequest;
        }

        public async Task<RentRequest> UpdateAsync(RentRequest request)
        {
            var requestAsJson = JsonSerializer.Serialize(request);
            StringContent payload = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{Url}/{request.Id}", payload);
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<RentRequest>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        public async Task<RentRequest> GetAsync(int id)
        {
            var response = await _client.GetAsync($"{Url}/{id}");
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<RentRequest>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        public async Task<IEnumerable<RentRequest>> GetAllAsync()
        {
            var response = await _client.GetAsync($"{Url}?status=APPROVED&?status=NOTAPPROVED");
            await HandleErrorResponse(response);

            return JsonSerializer.Deserialize<List<RentRequest>>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }

        public async Task<RentRequest> UpdateRentRequestStatusAsync(RentRequest request)
        {
            var requestAsJson = JsonSerializer.Serialize(request, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            HttpContent content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync($"{Url}/{request.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(
                    $"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var updatedRequest = JsonSerializer.Deserialize<RentRequest>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return updatedRequest;
        }

        public async Task<IEnumerable<RentRequest>> GetAllNotAnsweredRentRequestAsync()
        {
            var response = await _client.GetAsync($"{Url}?status=NOTANSWERED");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(
                    $"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            var requestList = JsonSerializer.Deserialize<List<RentRequest>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return requestList;
        }

        public async Task<IEnumerable<RentRequest>> GetRentRequestsByGuestId(int guestId)
        {
            var response = await _client.GetAsync($"{Url}?guestId={guestId}");
            Console.WriteLine(JsonSerializer.Serialize(await response.Content.ReadAsStringAsync()));
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<IEnumerable<RentRequest>>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        public async Task<IEnumerable<RentRequest>> GetRentRequestsByViaId(int viaId)
        {
            var response = await _client.GetAsync($"{Url}??viaId={viaId}");
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<IEnumerable<RentRequest>>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        private static async Task HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}