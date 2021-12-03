using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace SEP3T2GraphQL.Services
{
    public class ResidenceReviewServiceImpl : IResidenceService
    {
        private IResidenceRepository _residenceRepository;
        private IResidenceValidation _residenceValidation;

        public ResidenceReviewServiceImpl(IResidenceRepository residenceRepository)
        {
            _residenceRepository = residenceRepository;
            _residenceValidation = new ResidenceValidationImpl();
        }

        public async Task<Residence> GetResidenceByIdAsync(int id)
        {
            if (id is > 0 and < int.MaxValue && id !=null)
            {
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
            throw new Exception("ID must be bigger than 0");
        }

        public async Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence)
        {
            if (_residenceValidation.IsValidAvailabilityPeriod(residence.AvailableFrom, residence.AvailableTo))
            {

                return await _residenceRepository.UpdateResidenceAvailabilityAsync(residence);
            }
            throw new ArgumentException("Publish attempt failed ");
        }

        public async Task<Residence> CreateResidenceAsync(Residence residence)
        {
            if (_residenceValidation.IsValidResidence(residence))
            {
                try
                {
                    Console.WriteLine($"{this} creating new residence...");
                    Console.WriteLine($"{this}: Was passed this arg: {JsonConvert.SerializeObject(residence)}");
                    return await _residenceRepository.CreateResidenceAsync(residence);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            throw new ArgumentException("Invalid residence");
        }

        public async Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id)
        {
            if (id is > 0 and < int.MaxValue  && id !=null)
            {
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
            throw new Exception("ID must be bigger than 0");
        }

        public async Task<IList<Residence>> GetAvailableResidencesAsync()
        {
            var allResidences = await _residenceRepository.GetAllAsync();
            return allResidences.Where(r => r.IsAvailable).ToList(); 
        }
    }
}