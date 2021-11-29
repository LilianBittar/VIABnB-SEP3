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
            string requestAsJson = JsonSerializer.Serialize(request, new JsonSerializerOptions()
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
            var response = await _client.GetAsync(Url);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            await HandleErrorResponse(response);

            return JsonSerializer.Deserialize<List<RentRequest>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
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