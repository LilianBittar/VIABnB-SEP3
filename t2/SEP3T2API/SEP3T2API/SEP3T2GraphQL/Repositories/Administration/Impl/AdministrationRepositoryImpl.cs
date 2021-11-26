using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Administration.Impl
{
    public class AdministrationRepositoryImpl : IAdministrationRepository
    {
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;

        public AdministrationRepositoryImpl()
        {
            client = new HttpClient();
        }

        public async Task<Administrator> GetAdminByEmail(string email)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/admin?={email}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await responseMessage.Content.ReadAsStringAsync()} with status code {responseMessage.StatusCode}");
                throw new Exception(await responseMessage.Content.ReadAsStringAsync());
            }

            var adminToReturn =
                JsonSerializer.Deserialize<Administrator>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions(
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }));
            return adminToReturn;
        }

        public async Task<IEnumerable<Administrator>> GetAllAdmins()
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/admins");
            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await responseMessage.Content.ReadAsStringAsync()} with status code {responseMessage.StatusCode}");
                throw new Exception(await responseMessage.Content.ReadAsStringAsync());
            }

            var result = await responseMessage.Content.ReadAsStringAsync();
            var adminListToReturn = JsonSerializer.Deserialize<List<Administrator>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adminListToReturn;
        }

        public async Task<Administrator> ValidateAdmin(Administrator administrator)
        {
            var adminToValidate = await GetAdminByEmail(administrator.Email);
            if (adminToValidate == null)
            {
                throw new ArgumentException("Admin cant be found---> check for null");
            }

            return adminToValidate;
        }
    }
}