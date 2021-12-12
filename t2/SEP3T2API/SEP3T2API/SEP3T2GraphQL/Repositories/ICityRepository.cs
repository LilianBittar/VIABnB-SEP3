using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface ICityRepository
    {
        public Task<IEnumerable<City>> GetAllCityAsync();
        public Task<City> CreateCityAsync(City city);
    }
}