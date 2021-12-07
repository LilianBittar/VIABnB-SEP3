using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class FacilityRepository : IFacilityRepository
    {
        private string uri = "http://localhost:8080";
        private readonly HttpClient client = new HttpClient();
        
        public async Task<Facility> CreateFacility(Facility facility)
        {
            var facilityAsJson = JsonSerializer.Serialize(facility, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            HttpContent content = new StringContent(facilityAsJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{uri}/facility", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var newFacility = JsonSerializer.Deserialize<Facility>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return newFacility;
        }

        public async Task<IEnumerable<Facility>> GetAllFacilities()
        {
            var response = await client.GetAsync($"{uri}/facilities");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadAsStringAsync();
            var facilitiesToReturn = JsonSerializer.Deserialize<List<Facility>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return facilitiesToReturn;
        }

        public async Task<Facility> GetFacilityById(int id)
        {
            var response = await client.GetAsync($"{uri}/facility/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadAsStringAsync();
            var facilityToReturn = JsonSerializer.Deserialize<Facility>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return facilityToReturn;
        }

        public async Task<Facility> DeleteResidenceFacility(Facility facility, int residenceId)
        {
            var facilityAsJson = JsonSerializer.Serialize(facility, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var response = await client.DeleteAsync($"{uri}/residencefacilities/{facility.Id}/{residenceId}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var newFacility = JsonSerializer.Deserialize<Facility>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return newFacility;
        }
    }
}