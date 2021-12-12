using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IAddressService
    {
        /// <summary>
        /// Get a list of Address objects via repository
        /// </summary>
        /// <returns>A list containing all the addresses registered in the system</returns>
        public Task<IEnumerable<Address>> GetAllAddressAsync();
        /// <summary>
        /// Create a new Address object via repository
        /// </summary>
        /// <param name="address">The new Address</param>
        /// <returns>Address object</returns>
        /// <exception cref="ArgumentException">If  <c>StreetName</c>, <c>StreetNumber</c>, <c>HouseNumber</c> or <c>City</c>, of <c>address</c> is null or empty </exception>
        /// <exception cref="ArgumentException">If <c>StreetName</c> of <c>address</c> contains any chars that is not letter</exception>
        /// <exception cref="ArgumentException">If  <c>StreetName</c>, <c>StreetNumber</c> or <c>City</c>, of <c>address</c> is null or empty </exception>
        /// <exception cref="ArgumentException">If <c>StreetName</c> of <c>address</c> contains any chars that is not letter</exception>
        public Task<Address> CreateAddressAsync(Address address); 
    }
}