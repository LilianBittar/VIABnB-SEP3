using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _facilityRepository;

        public FacilityService(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<Facility> CreateResidenceFacilityAsync(Facility facility, int residenceId)
        {
            var newFacility = await _facilityRepository.CreateResidenceFacilityAsync(facility, residenceId);

            if (newFacility == null)
            {
                throw new Exception("Facility can't be null");
            }

            return newFacility;
        }

        public async Task<IEnumerable<Facility>> GetAllFacilitiesAsync()
        {
            var facilityListToReturn = await _facilityRepository.GetAllFacilitiesAsync();
            if (facilityListToReturn == null)
            {
                throw new Exception("Facility list can't be null");
            }

            return facilityListToReturn;
        }

        public async Task<Facility> GetFacilityByIdAsync(int id)
        {
            var facilityToReturn = await _facilityRepository.GetFacilityByIdAsync(id);
            if (facilityToReturn == null)
            {
                throw new Exception("Facility can't be null");
            }

            return facilityToReturn;
        }

        public async Task<Facility> DeleteResidenceFacilityAsync(Facility facility, int residenceId)
        {
            try
            {
               return await _facilityRepository.DeleteResidenceFacilityAsync(facility, residenceId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}