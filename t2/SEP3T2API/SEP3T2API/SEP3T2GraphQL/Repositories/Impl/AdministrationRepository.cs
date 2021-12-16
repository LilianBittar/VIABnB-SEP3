using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private const string Uri = "http://localhost:8080";
        private readonly HttpClient _client;

        public AdministrationRepository()
        {
            _client = new HttpClient();
        }

        public async Task<Administrator> GetAdminByEmailAsync(string email)
        {
            var responseMessage = await _client.GetAsync($"{Uri}/admin/{email}");
            if (string.IsNullOrEmpty(await responseMessage.Content.ReadAsStringAsync()))
            {
                return null;
            }
            await HandleErrorResponse(responseMessage);

            var adminToReturn =
                JsonSerializer.Deserialize<Administrator>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions(
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }));
            return adminToReturn;
        }

        public async Task<IEnumerable<Administrator>> GetAllAdminsAsync()
        {
            var responseMessage = await _client.GetAsync($"{Uri}/admins");
            await HandleErrorResponse(responseMessage);

            var result = await responseMessage.Content.ReadAsStringAsync();
            var adminListToReturn = JsonSerializer.Deserialize<List<Administrator>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adminListToReturn;
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