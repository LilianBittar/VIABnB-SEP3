﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public class ResidenceRepositoryImpl: IResidenceRepository
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public ResidenceRepositoryImpl()
        {
            client = new HttpClient();
        }

        public async Task<Residence> GetResidenceByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/Residence/{id}");

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
            string newResidence = JsonSerializer.Serialize(residence);
            StringContent content = new StringContent(newResidence, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Residence", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            Residence r = JsonSerializer.Deserialize<Residence>(await responseMessage.Content.ReadAsStringAsync());
            return r;
        }

        public async Task<IList<Residence>> GetAllMyResidencesAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Residence");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Residence> residences = JsonSerializer.Deserialize<List<Residence>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return residences;
        }
    }
}