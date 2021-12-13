using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface ICityService
    {
        /// <summary>
        /// Get a list of City objects via repository
        /// </summary>
        /// <returns>List of City objects</returns>
        public Task<IEnumerable<City>> GetAllCityAsync();
        /// <summary>
        /// Create a new City object via repository
        /// </summary>
        /// <param name="city">The new City</param>
        /// <returns>The newly created City object</returns>
        public Task<City> CreateCityAsync(City city);
    }
}