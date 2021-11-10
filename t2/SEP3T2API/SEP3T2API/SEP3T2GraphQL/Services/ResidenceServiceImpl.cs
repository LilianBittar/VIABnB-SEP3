using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace SEP3T2GraphQL.Services
{
    public class ResidenceServiceImpl : IResidenceService
    {
        private IResidenceRepository _residenceRepository;
        private IResidenceValidation _residenceValidation;

        public ResidenceServiceImpl(IResidenceRepository residenceRepository)
        {
            _residenceRepository = residenceRepository;
            _residenceValidation = new ResidenceValidationImpl();
        }

        public async Task<Residence> GetResidenceByIdAsync(int id)
        {
            //TODO validation on residence id and null goes here
            try
            {
                return await _residenceRepository.GetResidenceByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Residence> CreateResidenceAsync(Residence residence)
        {
            if (_residenceValidation.IsValidResidence(residence))
            {
                try
                {
                    Console.WriteLine($"{this} creating new residence...");
                    Console.WriteLine($"{this}: Was passed this arg: {JsonConvert.SerializeObject(residence)}");
                    return  await _residenceRepository.CreateResidenceAsync(residence);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            throw new ArgumentException("Invalid residence!!");
        }

        public async Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id)
        {
            //TODO validation on host id goes here 
            try
            {
                return await _residenceRepository.GetAllRegisteredResidencesByHostIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    
    }
}