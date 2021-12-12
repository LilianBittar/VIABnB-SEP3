using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IAddressService
    {
        public Task<IEnumerable<Address>> GetAllAddressAsync();
        public Task<Address> CreateAddressAsync(Address address); 
    }
}