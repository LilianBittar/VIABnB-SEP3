using System;
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
            try
            {
                return await _residenceRepository.GetResidenceById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task CreateResidenceAsync(Residence residence)
        {
            try
            {
                await _residenceRepository.CreateResidenceAsync(residence);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}