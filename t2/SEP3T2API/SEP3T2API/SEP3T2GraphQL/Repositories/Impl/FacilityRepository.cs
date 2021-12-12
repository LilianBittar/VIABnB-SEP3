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
        private const string Uri = "http://localhost:8080";
        private readonly HttpClient _client;

        public FacilityRepository()
        {
            _client = new HttpClient();
        }

        public async Task<Facility> CreateResidenceFacilityAsync(Facility facility, int residenceId)
        {
            var facilityAsJson = JsonSerializer.Serialize(facility, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(facilityAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{Uri}/facility/{facility.Id}/{residenceId}", content);
            await HandleErrorResponse(response);
            var newFacility = JsonSerializer.Deserialize<Facility>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return newFacility;
        }

        public async Task<IEnumerable<Facility>> GetAllFacilitiesAsync()
        {
            var response = await _client.GetAsync($"{Uri}/facilities");
            await HandleErrorResponse(response);
            var result = await response.Content.ReadAsStringAsync();
            var facilitiesToReturn = JsonSerializer.Deserialize<List<Facility>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return facilitiesToReturn;
        }

        public async Task<Facility> GetFacilityByIdAsync(int id)
        {
            var response = await _client.GetAsync($"{Uri}/facility/{id}");
            await HandleErrorResponse(response);
            var result = await response.Content.ReadAsStringAsync();
            var facilityToReturn = JsonSerializer.Deserialize<Facility>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return facilityToReturn;
        }

        public async Task<Facility> DeleteResidenceFacilityAsync(Facility facility, int residenceId)
        {
            var facilityAsJson = JsonSerializer.Serialize(facility, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var response = await _client.DeleteAsync($"{Uri}/residencefacilities/{facility.Id}/{residenceId}");
            await HandleErrorResponse(response);

            return facility;
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