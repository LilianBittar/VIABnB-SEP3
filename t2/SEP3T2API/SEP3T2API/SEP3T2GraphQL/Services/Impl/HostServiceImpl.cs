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
            
            if (_hostValidation.IsValidEmail(email))
            {
                try
                {
                    Console.WriteLine($"{this} logging in...");
                    Console.WriteLine($"{this}: Was passed this arg: {JsonConvert.SerializeObject(email)}");
                    return await _hostRepository.GetHostByEmail(email);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            throw new ArgumentException("No user with such email");
        }

        public async Task<Host> ValidateHostAsync(string email, string password)
        {
            var returnedHost = await GetHostByEmail(email);
            if (returnedHost == null) throw new KeyNotFoundException("user not found");
            if (returnedHost.Password != password)
            {
                throw new Exception("the password is not matching");
            }
            else return returnedHost;
        }

      

        public async Task<Host> GetHostById(int id)
        {
            //Todo move this to  HostRepository, call HostRepository add business logic if needed, such as what happens if null is found?.  

            if (id is > 0 and < int.MaxValue && id != null)
            {
                try
                {
                    return await _hostRepository.GetHostById(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            throw new Exception("Id must be bigger than 0");
        }

        public async Task<IEnumerable<Host>> GetAllNotApprovedHostsAsync()
        {
            var hostListToReturn = await _hostRepository.GetAllNotApprovedHosts();
            if (hostListToReturn == null)
            {
                throw new ArgumentException("Host list is null");
            }

            return hostListToReturn;
        }

        public async Task<Host> UpdateHostStatusAsync(Host host)
        { 
            Console.WriteLine($"{this} {nameof(UpdateHostStatusAsync)} received params: {JsonSerializer.Serialize(host)}");
            if (host == null)
            {
                throw new ArgumentException("Host can't be null");
            }

            var updatedHost = await _hostRepository.UpdateHostStatus(host);
            if (updatedHost == null)
            {
                throw new ArgumentException("Can't update the host status!!!");
            }

            return updatedHost;
        }
    }
}