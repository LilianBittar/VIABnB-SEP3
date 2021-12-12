using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class HostReviewRepository : IHostReviewRepository
    {
        private const string Uri = "http://localhost:8080/hostreviews";
        private readonly HttpClient _client;

        public HostReviewRepository()
        {
            _client = new HttpClient();
        }
        
        public async Task<HostReview> CreateHostReviewAsync(HostReview hostReview)
        {
            var hostAsJson = JsonSerializer.Serialize(hostReview, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var payload = new StringContent(hostAsJson, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(Uri, payload);
            await HandleErrorResponse(response);
            var createdHostReview = JsonSerializer.Deserialize<HostReview>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return createdHostReview;
        }

        public async Task<HostReview> UpdateHostReviewAsync(HostReview hostReview)
        {
            var hostAsJson = JsonSerializer.Serialize(hostReview, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(hostAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{Uri}/host/{hostReview.hostId}", content);
            await HandleErrorResponse(response);

            var updatedHostReview = JsonSerializer.Deserialize<Models.HostReview>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return updatedHostReview;
        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByGuestIdAsync(int id)
        {
            var response = await _client.GetAsync($"{Uri}/host/{id}");
            await HandleErrorResponse(response);
            var result = await response.Content.ReadAsStringAsync();
            var responseList = JsonSerializer.Deserialize<List<HostReview>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return responseList;
        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id)
        {
            var response = await _client.GetAsync($"{Uri}/host/{id}");
            await HandleErrorResponse(response);
            var result = await response.Content.ReadAsStringAsync();
            var responseList = JsonSerializer.Deserialize<List<HostReview>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return responseList;
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