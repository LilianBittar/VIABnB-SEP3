using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class ResidenceRepositoryImpl: IResidenceRepository
    {
        private const string Uri = "http://localhost:8080";
        private readonly HttpClient _client;
        public ResidenceRepositoryImpl()
        {
            _client = new HttpClient();
        }

        public async Task<Residence> GetResidenceByIdAsync(int id)
        {
            var responseMessage = await _client.GetAsync(Uri + $"/residences/{id}");
            await HandleErrorResponse(responseMessage);
            var result = await responseMessage.Content.ReadAsStringAsync();
            var residence = JsonSerializer.Deserialize<Residence>(result, new JsonSerializerOptions(
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }));
            return residence;
            
            
        }
        

        public async Task<Residence> CreateResidenceAsync(Residence residence)
        {
            residence.Id = this.GetTheLastAddedResidence().Id + 1;
            var newResidence = JsonSerializer.Serialize(residence, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(newResidence, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync(Uri + "/residences", content);
            await HandleErrorResponse(responseMessage);
            
            var r = JsonSerializer.Deserialize<Residence>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return r;
        }

        public async Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence)
        {
            var guestAsJson = JsonSerializer.Serialize(residence, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(guestAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{Uri}/residences/{residence.Id}", content);
            await HandleErrorResponse(response);
            
            return residence;
        }

        public async Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id)
        {
            var responseMessage = await _client.GetAsync($"{Uri}/residence/host/{id}");

            await HandleErrorResponse(responseMessage);

            var result = await responseMessage.Content.ReadAsStringAsync();

            var residences = JsonSerializer.Deserialize<List<Residence>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return residences;
        }

        public async Task<IList<Residence>> GetAllResidenceAsync()
        {
            var response = await _client.GetAsync($"{Uri}/residences");
            await HandleErrorResponse(response);
            var residences = JsonSerializer.Deserialize<IList<Residence>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return residences;
        }

        public async Task<Residence> UpdateResidenceAsync(Residence residence)
        {
            var residenceAsJson = JsonSerializer.Serialize(residence, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(residenceAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync($"{Uri}/residences/{residence.Id}", content);
            await HandleErrorResponse(response);

            var updatedResidence = JsonSerializer.Deserialize<Residence>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return updatedResidence;
        }

        public async Task<Residence> DeleteResidenceAsync(Residence residence)
        {
            var deleteResidence = JsonSerializer.Serialize(residence, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var response = await _client.DeleteAsync($"{Uri}/residences/{residence.Id}");
            await HandleErrorResponse(response);
            
            return residence;
        }

        private static async Task HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync()+" " + response.StatusCode);
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<Residence> GetTheLastAddedResidence()
        {
            var responseMessage = await _client.GetAsync($"{Uri}/residence");

            await HandleErrorResponse(responseMessage);
            var result = await responseMessage.Content.ReadAsStringAsync();

            var residences = JsonSerializer.Deserialize<List<Residence>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return residences[residences.Capacity - 1];
        }

    }
}