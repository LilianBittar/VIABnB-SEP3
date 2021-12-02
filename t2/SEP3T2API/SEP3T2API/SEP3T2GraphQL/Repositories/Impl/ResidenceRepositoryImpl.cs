using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class ResidenceRepositoryImpl: IResidenceRepository
    {
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;
        private IResidenceValidation _residenceValidation;

        public ResidenceRepositoryImpl()
        {
           
            client = new HttpClient();
        }

        public async Task<Residence> GetResidenceByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/residences/{id}");

            await HandleErrorResponse(responseMessage);


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
            residence.Id = this.GetTheLastAddedResidence().Id + 1;
            System.Console.WriteLine($"{this} was passed args: {JsonSerializer.Serialize(residence)}");
            string newResidence = JsonSerializer.Serialize(residence, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Console.WriteLine(newResidence);
            StringContent content = new StringContent(newResidence, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/residences", content);
            await HandleErrorResponse(responseMessage);


            Residence r = JsonSerializer.Deserialize<Residence>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Console.WriteLine(r.ToString()); 
            return r;
        }

        public async Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence)
        {
            var guestAsJson = JsonSerializer.Serialize(residence, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            HttpContent content = new StringContent(guestAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/{residence.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var updatedResidence = JsonSerializer.Deserialize<Residence>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return updatedResidence;
        }

        public async Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/residence/{id}");

            await HandleErrorResponse(responseMessage);

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Residence> residences = JsonSerializer.Deserialize<List<Residence>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return residences;
        }

        public async Task<IList<Residence>> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/residences");
             await HandleErrorResponse(response);
             var residences = JsonSerializer.Deserialize<IList<Residence>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
             {
                 PropertyNamingPolicy = JsonNamingPolicy.CamelCase
             });
             return residences;
        }

        private static async Task HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<Residence> GetTheLastAddedResidence()
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/residence");

            await HandleErrorResponse(responseMessage);
            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Residence> residences = JsonSerializer.Deserialize<List<Residence>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return residences[residences.Capacity - 1];
        }

    }
}