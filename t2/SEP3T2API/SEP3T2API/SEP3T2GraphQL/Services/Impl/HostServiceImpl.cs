using System;
using System.Collections.Generic;
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
        private readonly HttpClient client = new HttpClient();
        private IHostRepository _hostRepository;
        private IHostValidation _hostValidation;

        public HostServiceImpl(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
            _hostValidation = new HostValidationImpl();
        }


        public Task<Host> UpdateHost(Host host)
        {
            throw new NotImplementedException();
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

        public async Task<Host> ValidateHostAsync(string email, string password)
        {
            var returnedHost = await GetHostByEmail(email);
            if (returnedHost == null) throw new KeyNotFoundException("user not found");
            if (returnedHost.Password != password)
            {
                throw new Exception("the password is not matching");
            }
            else return null;
        }

      

        public async Task<Host> GetHostById(int id)
        {
            //Todo move this to  HostRepository, call HostRepository add business logic if needed, such as what happens if null is found?.  
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/host/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Host host = JsonSerializer.Deserialize<Host>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return host;
        }

        public async Task<IList<Host>> GetAllNotApprovedHostsAsync()
        {
            return await _hostRepository.GetAllNotApprovedHosts();
        }

        public async Task<Host> UpdateHostStatusAsync(Host host)
        { 
            Console.WriteLine($"{this} {nameof(UpdateHostStatusAsync)} received params: {JsonSerializer.Serialize(host)}");
            if (host == null)
            {
                throw new ArgumentException("Host cant be null");
            }

            var updatedHost = await _hostRepository.UpdateHostStatus(host);
            if (updatedHost == null)
            {
                throw new Exception("Cant update the host status!!!");
            }

            return updatedHost;
        }
    }
}