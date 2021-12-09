using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class GuestReviewHost : IGuestReviewHostRepository
    {
        private string uri = "http://localhost:8080/guestreviews";
        private readonly HttpClient client;
        
        public GuestReviewHost()
        {
            client = new HttpClient();
        }
        
        public async Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview)
        {
            var guestAsJson = JsonSerializer.Serialize(guestReview, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            StringContent payload = new(guestAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, payload);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

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
            HttpContent content = new StringContent(guestAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/{guestReview.GuestId}", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var updatedGuestReview = JsonSerializer.Deserialize<GuestReview>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return updatedGuestReview;
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByHostIdAsync(int id)
        {
            var response = await client.GetAsync($"{uri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadAsStringAsync();
            var responseList = JsonSerializer.Deserialize<List<GuestReview>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return responseList;
        }
    }
}