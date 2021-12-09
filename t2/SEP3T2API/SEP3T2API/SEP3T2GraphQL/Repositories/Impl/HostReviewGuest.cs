using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class HostReviewGuest : IHostReviewGuestRepository
    {
        private string uri = "http://localhost:8080/hostreviews";
        private readonly HttpClient client;

        public HostReviewGuest()
        {
            client = new HttpClient();
        }
        
        public async Task<HostReview> CreateHostReviewAsync(HostReview hostReview)
        {
            var hostAsJson = JsonSerializer.Serialize(hostReview, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            StringContent payload = new(hostAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, payload);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

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
            HttpContent content = new StringContent(hostAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/{hostReview.hostId}", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var updatedHostReview = JsonSerializer.Deserialize<HostReview>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return updatedHostReview;
        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByGuestIdAsync(int id)
        {
            var response = await client.GetAsync($"{uri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadAsStringAsync();
            var responseList = JsonSerializer.Deserialize<List<HostReview>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return responseList;
        }

        public async Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id)
        {
            var response = await client.GetAsync($"{uri}/host/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadAsStringAsync();
            var responseList = JsonSerializer.Deserialize<List<HostReview>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return responseList;
        }
    }
}