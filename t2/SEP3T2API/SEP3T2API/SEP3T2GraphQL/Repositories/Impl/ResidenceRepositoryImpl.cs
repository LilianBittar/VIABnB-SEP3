using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace SEP3T2GraphQL.Repositories
{
    public class ResidenceRepositoryImpl: IResidenceRepository
    {
        // Todo id must be incremented based on all residences/ or just leave it to the database serial attribute
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;
        private IResidenceValidation _residenceValidation;

        public ResidenceRepositoryImpl(IResidenceValidation residenceValidation)
        {
            _residenceValidation = residenceValidation; 
            client = new HttpClient();
        }

        public async Task<Residence> GetResidenceByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/residence/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Residence residence = JsonSerializer.Deserialize<Residence>(result, new JsonSerializerOptions(
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }));
            return residence;
        }

        public async Task<Residence> CreateResidenceAsync(Residence residence)
        {
            System.Console.WriteLine($"{this} was passed args: {JsonSerializer.Serialize(residence)}");
            string newResidence = JsonSerializer.Serialize(residence, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Console.WriteLine(newResidence);
            StringContent content = new StringContent(newResidence, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/residence", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            Residence r = JsonSerializer.Deserialize<Residence>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Console.WriteLine(r.ToString()); 
            return r;
        }

        public async Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/residence/{id}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Residence> residences = JsonSerializer.Deserialize<List<Residence>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return residences;
        }
        
    }
}