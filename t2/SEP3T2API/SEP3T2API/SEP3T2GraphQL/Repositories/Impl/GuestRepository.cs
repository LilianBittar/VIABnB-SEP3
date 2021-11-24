using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class GuestRepository : IGuestRepository
    {
        private readonly HttpClient _client = new HttpClient();
        private const string Uri = "http://localhost:8080/guests";

        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            var guestAsJson = JsonSerializer.Serialize(guest, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            StringContent payload = new(guestAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(Uri, payload);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var createdGuest = JsonSerializer.Deserialize<Guest>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return createdGuest;
        }
    }
}