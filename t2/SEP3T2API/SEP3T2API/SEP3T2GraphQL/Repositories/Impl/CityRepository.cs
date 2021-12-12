using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class CityRepository : ICityRepository
    {
        private readonly HttpClient _client;
        private const string Uri = "http://localhost:8080/cities";

        public CityRepository()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<City>> GetAllCityAsync()
        {
            var response = await _client.GetAsync(Uri);
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<IEnumerable<City>>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        public async Task<City> CreateCityAsync(City city)
        {
            var cityAsJson = JsonSerializer.Serialize(city,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            StringContent payload = new(cityAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(Uri, payload);
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<City>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase}); 
        }

        private static async Task HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
        }
    }
}