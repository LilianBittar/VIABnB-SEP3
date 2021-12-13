using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface ICityRepository
    {
        /// <summary>
        /// Get a list of City objects via API
        /// </summary>
        /// <returns>List of City objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<IEnumerable<City>> GetAllCityAsync();
        /// <summary>
        /// Create a new City object via API
        /// </summary>
        /// <param name="city">The new City</param>
        /// <returns>The newly created City object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<City> CreateCityAsync(City city);
    }
}