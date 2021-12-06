using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IAddressRepository
    {
        public Task<IEnumerable<Address>> GetAllAsync();
        public Task<Address> CreateAsync(Address address); 
    }
}