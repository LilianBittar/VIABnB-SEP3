using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class HostRepository : IHostRepository
    {
        private const string Uri = "http://localhost:8080";
        private readonly HttpClient _client;

        public HostRepository()
        {
            _client = new HttpClient();
        }
        
        public async Task<Host> RegisterHostAsync(Host host)
        {

            var newHost = JsonSerializer.Serialize(host, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            Console.WriteLine(newHost);
            var content = new StringContent(newHost, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync(Uri + "/host", content);
            await HandleErrorResponse(responseMessage);

            var h = JsonSerializer.Deserialize<Host>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return h;
        }


        public async Task<Host> GetHostByEmailAsync(string email)
        {
            var response = await _client.GetAsync(Uri + $"/host?email={email}");
            await HandleErrorResponse(response);
            
            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(result))
            {
                return null;
            }
            var host = JsonSerializer.Deserialize<Host>(result, new JsonSerializerOptions(
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));
            return host;
        }

        public async Task<Host> GetHostByIdAsync(int id)
        {
            var responseMessage = await _client.GetAsync(Uri + $"/host/{id}");

            await HandleErrorResponse(responseMessage);

            var result = await responseMessage.Content.ReadAsStringAsync();
            var host = JsonSerializer.Deserialize<Host>(result, new JsonSerializerOptions(
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }));
            return host;
        }

        public async Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync()
        {
            var response = await _client.GetAsync(Uri + $"/hosts/notApproved");
            await HandleErrorResponse(response);

            var result = await response.Content.ReadAsStringAsync();
            var hostListToReturn = JsonSerializer.Deserialize<List<Host>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return hostListToReturn;
        }

        public async Task<Host> UpdateHostStatusAsync(Host host)
        {
            var hostAsJson = JsonSerializer.Serialize(host, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(hostAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync($"{Uri}/hosts/{host.Id}/approval", content);
            await HandleErrorResponse(response);

            var updatedHost = JsonSerializer.Deserialize<Host>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return updatedHost;
        }
        
        private static async Task HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync()+" " + response.StatusCode);
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}