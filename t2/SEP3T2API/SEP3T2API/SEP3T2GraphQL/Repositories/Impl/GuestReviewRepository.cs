using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class GuestReviewRepository : IGuestReviewRepository
    {
        private const string Uri = "http://localhost:8080/guestreviews";
        private readonly HttpClient _client;
        
        public GuestReviewRepository()
        {
            _client = new HttpClient();
        }
        
        public async Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview)
        {
            var guestAsJson = JsonSerializer.Serialize(guestReview, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var payload = new StringContent(guestAsJson, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(Uri, payload);
            await HandleErrorResponse(response);
            var createdGuestReview = JsonSerializer.Deserialize<GuestReview>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return createdGuestReview;
        }

        public async Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview)
        {
            var guestAsJson = JsonSerializer.Serialize(guestReview, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(guestAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{Uri}/guest/{guestReview.GuestId}", content);
            await HandleErrorResponse(response);
            var updatedGuestReview = JsonSerializer.Deserialize<GuestReview>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return updatedGuestReview;
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByHostIdAsync(int id)
        {
            var response = await _client.GetAsync($"{Uri}/guest/{id}");
            await HandleErrorResponse(response);
            var result = await response.Content.ReadAsStringAsync();
            var responseList = JsonSerializer.Deserialize<List<GuestReview>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return responseList;
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id)
        {
            var response = await _client.GetAsync($"{Uri}/guest/{id}");
            await HandleErrorResponse(response);

            var result = await response.Content.ReadAsStringAsync();
            var responseList = JsonSerializer.Deserialize<List<GuestReview>>(result, new JsonSerializerOptions
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