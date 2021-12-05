using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class GuestReviewRepository : IGuestReviewRepository
    {
        private string uri = "http://localhost:8080/guestreviews";
        private readonly HttpClient client;

        public GuestReviewRepository()
        {
            client = new HttpClient();
        }

        public Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id)
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