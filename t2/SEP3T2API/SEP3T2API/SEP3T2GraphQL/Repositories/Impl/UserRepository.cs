using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _client = new HttpClient();
        private const string Uri = "http://localhost:8080/users";


        public async Task<User> GetUserByEmailAsync(string email)
        {
            var response = await _client.GetAsync($"{Uri}?email={email}");
            await HandleErrorResponse(response);
            var user = JsonSerializer.Deserialize<User[]>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return user[0];
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = await _client.GetAsync($"{Uri}/{id}");
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var response = await _client.GetAsync(Uri);
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<IEnumerable<User>>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
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