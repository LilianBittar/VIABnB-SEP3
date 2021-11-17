using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3T2GraphQL.Services.Impl
{
    public class HostServiceImpl : IHostService
    {
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;
        private IHostRepository _hostRepository;
        private IHostValidation _hostValidation;

        public HostServiceImpl(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
            _hostValidation = new HostValidationImpl();
        }


        public async Task<Host> RegisterHostAsync(Host host)
        {
            if (_hostValidation.IsValidHost(host))
            {
                try
                {
                    Console.WriteLine($"{this} creating new host...");
                    Console.WriteLine($"{this}: Was passed this arg: {JsonConvert.SerializeObject(host)}");
                    return await _hostRepository.RegisterHostAsync(host);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            throw new ArgumentException("Invalid host");
        }

        public async Task<Host> GetHostByEmail(string email)
        {
            //Todo call repo + if logic if needed 
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/host?email={email}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Host host = JsonSerializer.Deserialize<Host>(result, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return host;
        }

        public async Task<Host> ValidateHostAsync(Host host)
        {
            var returnedHost = await GetHostByEmail(host.Email);
            if (returnedHost != null && returnedHost.Password == host.Password)
            {
                return host;
            }
            else return null;
        }

      

        public async Task<Host> GetHostById(int id)
        {
            //Todo call repo + if logic if needed 
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/host/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Host host = JsonSerializer.Deserialize<Host>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return host;
        }
    }
}