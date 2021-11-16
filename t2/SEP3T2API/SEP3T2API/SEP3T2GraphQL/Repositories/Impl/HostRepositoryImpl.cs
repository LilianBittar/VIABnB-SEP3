using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.HostValidation;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class HostRepositoryImpl : IHostRepository
    {
        
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;
        private IHostValidation _hostValidation;

        public HostRepositoryImpl(IHostValidation hostValidation)
        {
            _hostValidation = hostValidation; 
            client = new HttpClient();
        }
        
        public async Task<Host> RegisterHostAsync(Host host)
        {
            System.Console.WriteLine($"{this} was passed args: {JsonSerializer.Serialize(host)}");
            
            string newHost = JsonSerializer.Serialize(host, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            Console.WriteLine(newHost);
            StringContent content = new StringContent(newHost, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/host", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            Host h = JsonSerializer.Deserialize<Host>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Console.WriteLine(h.ToString()); 
            return h;
        }
        
        
        
    }
}