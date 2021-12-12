using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly CreateCityValidator _createCityValidator;

        public CityService(ICityRepository cityRepository, CreateCityValidator createCityValidator)
        {
            _cityRepository = cityRepository;
            _createCityValidator = createCityValidator;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllCityAsync();
        }

        public async Task<City> CreateAsync(City city)
        {
            _createCityValidator.Validate(city);
            return await _cityRepository.CreateCityAsync(city);
        }
    }
}