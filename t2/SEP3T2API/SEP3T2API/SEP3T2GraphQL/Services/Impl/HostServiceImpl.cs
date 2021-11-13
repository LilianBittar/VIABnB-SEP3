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
    }
}