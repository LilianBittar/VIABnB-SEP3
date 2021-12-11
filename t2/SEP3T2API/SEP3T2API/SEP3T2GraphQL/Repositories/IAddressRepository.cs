using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IAddressRepository
    {
        /// <summary>
        /// Method that gets all the addresses and returns them in a list
        /// </summary>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>A list containing all the addresses registered in the system</returns>
        public Task<IEnumerable<Address>> GetAllAsync();
        
        /// <summary>
        /// Method that creates an address and stored in the system 
        /// </summary>
        /// <param name="address">The targeted Address to stored in the system </param>
        /// <exception cref="Exception">Thrown if the API response is not successful</exception>
        /// <returns>Address object</returns>
        public Task<Address> CreateAsync(Address address); 
    }
}