using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services
{
    public class ResidenceServiceImpl : IResidenceService
    {
        private IResidenceRepository _residenceRepository;

        public ResidenceServiceImpl(IResidenceRepository residenceRepository)
        {
            _residenceRepository = residenceRepository;
        }

        public async Task<Residence> GetResidenceByIdAsync(int id)
        {
            //TODO implement logic
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
            //TODO implement logic
            try
            {
               return  await _residenceRepository.CreateResidenceAsync(residence);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Residence>> GetAllMyResidencesAsync()
        {
            //TODO implement logic
            try
            {
                return  await _residenceRepository.GetAllMyResidencesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}