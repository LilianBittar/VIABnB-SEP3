using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;

namespace SEP3T2GraphQL.Services.Impl
{
    public class HostServiceImpl :IHostService
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
            return email;
        }

       public async Task<Host> ValidateHostAsync(Host host)
       {
           return null;
       }

        public async Task<Host> GetHostById(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/host/{id}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
            Host host =  JsonSerializer.Deserialize<Residence>(result, new JsonSerializerOptions(
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }));
            return host;
            string result = await responseMessage.Content.ReadAsStringAsync();
        }
    }
}