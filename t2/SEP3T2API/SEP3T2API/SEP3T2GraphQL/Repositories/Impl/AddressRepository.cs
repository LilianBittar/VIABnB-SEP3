using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HttpClient _client = new();
        private const string Uri = "http://localhost:8080/addresses";


        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            var response = await _client.GetAsync(Uri);
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<IEnumerable<Address>>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        public async Task<Address> CreateAsync(Address address)
        {
            var addressAsJson = JsonSerializer.Serialize(address,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            StringContent payload = new(addressAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(Uri, payload);
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<Address>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        private async Task HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
        }
    }
}