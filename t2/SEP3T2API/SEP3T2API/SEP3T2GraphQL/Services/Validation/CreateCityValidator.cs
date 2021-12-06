using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateCityValidator
    {
        private readonly ICityRepository _cityRepository;

        public CreateCityValidator(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Validate(City city)
        {
            //TODO: Implement this. 
        }
    }
}