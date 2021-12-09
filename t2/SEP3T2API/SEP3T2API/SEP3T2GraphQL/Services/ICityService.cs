using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface ICityService
    {
        public Task<IEnumerable<City>> GetAllAsync();
        public Task<City> CreateAsync(City city);
    }
}