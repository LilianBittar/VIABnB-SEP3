using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface ICityRepository
    {
        public Task<IEnumerable<City>> GetAllAsync();
        public Task<City> CreateAsync(City city);
    }
}