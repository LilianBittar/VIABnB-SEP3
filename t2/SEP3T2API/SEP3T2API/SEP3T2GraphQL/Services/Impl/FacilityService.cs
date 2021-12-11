using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public class FacilityService : IFacilityService
    {
        private IFacilityRepository _facilityRepository;

        public FacilityService(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<Facility> CreateResidenceFacility(Facility facility, int residenceId)
        {
            var newFacility = await _facilityRepository.CreateResidenceFacility(facility, residenceId);

            if (newFacility == null)
            {
                throw new Exception("Facility can't be null");
            }

            return newFacility;
        }

        public async Task<IEnumerable<Facility>> GetAllFacilities()
        {
            var facilityListToReturn = await _facilityRepository.GetAllFacilities();
            if (facilityListToReturn == null)
            {
                throw new Exception("Facility list can't be null");
            }

            return facilityListToReturn;
        }

        public async Task<Facility> GetFacilityById(int id)
        {
            var facilityToReturn = await _facilityRepository.GetFacilityById(id);
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
               return await _facilityRepository.DeleteResidenceFacility(facility, residenceId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}