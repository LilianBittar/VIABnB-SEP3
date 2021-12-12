using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IAddressRepository
    {
        /// <summary>
        /// Get a list of Address objects via API
        /// </summary>
        /// <returns>A list containing all the addresses registered in the system</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<IEnumerable<Address>> GetAllAddressAsync();
        
        /// <summary>
        /// Create a new Address object via API
        /// </summary>
        /// <param name="address">The new Address</param>
        /// <returns>Address object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<Address> CreateAddressAsync(Address address); 
    }
}