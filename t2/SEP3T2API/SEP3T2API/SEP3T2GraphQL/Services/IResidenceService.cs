using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services
{ /// <summary>
    /// Business logic related to Residences are contained in this service.
    /// This service makes use of an ResidenceRepository, which is responsible for making
    /// contact to the Database Server.
    /// This separation of components are done such that the Database servers communication paradigm can change without
    /// having to rewrite the business logic in another Service implementation. 
    /// </summary>
    public interface IResidenceService
    {
        /// <summary>
        /// Get a Residence object by the given parameter via Repository
        /// </summary>
        /// <param name="id">The targeted Residence's id</param>
        /// <returns>A Residence object</returns>
        /// <exception cref="System.Exception">Thrown if the API throws exceptions</exception>
        /// <exception cref="System.Exception">If the Residence's id is a negative number</exception>
        Task<Residence> GetResidenceByIdAsync(int id);
        /// <summary>
        /// Update a Residence availability via Repository
        /// </summary>
        /// <param name="residence">The targeted Residence for update</param>
        /// <returns>An updated Residence object</returns>
        /// <exception cref="System.ArgumentException">If the start and end date is null</exception>
        /// <exception cref="System.ArgumentException">If the start and end date is earler than today's date</exception>
        /// <exception cref="System.ArgumentException">If the start date is earlier that the end date</exception>
        /// <exception cref="System.ArgumentException">If API cant execute the method</exception>
        Task<Residence> UpdateResidenceAvailabilityAsync(Residence residence);
        /// <summary>
        /// Create a new Residence object via Repository
        /// </summary>
        /// <param name="residence">The new Residence</param>
        /// <returns>A Residence object</returns>
        /// <exception cref="System.ArgumentException">If the start and end date is null</exception>
        /// <exception cref="System.ArgumentException">If the start and end date is earler than today's date</exception>
        /// <exception cref="System.ArgumentException">If the start date is earlier that the end date</exception>
        /// <exception cref="System.ArgumentException">If the Residence is null</exception>
        /// <exception cref="System.ArgumentException">If the Residence's id is a negative number</exception>
        /// <exception cref="System.ArgumentException">If the Residence's description is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's type is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's price per night is a negative number</exception>
        /// <exception cref="System.ArgumentException">If the Residence's max number of guests is a negative number</exception>
        /// <exception cref="System.ArgumentException">If the Residence's facilities are null</exception>
        /// <exception cref="System.ArgumentException">If the Residence's facilities' id are negative numbers</exception>
        /// <exception cref="System.ArgumentException">If the Residence's facilities' name is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's rules are null</exception>
        /// <exception cref="System.ArgumentException">If the Residence's rules' description is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's Address is null</exception>
        /// <exception cref="System.ArgumentException">If the Residence's Address's Street number is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's Address's Street name is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's Address's House number is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's Address's id is a negative number</exception>
        /// <exception cref="System.ArgumentException">If the Residence's Address's City's name is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's Address's City's zip code is less that 1000 and greater that 9999</exception>
        /// <exception cref="System.Exception">If API cant execute the method</exception>
        Task<Residence> CreateResidenceAsync(Residence residence); 
        /// <summary>
        /// Get a list of Residence objects by a given parameter via Repository
        /// </summary>
        /// <param name="id">The Host's id who own the Residences</param>
        /// <returns>A list of Residence objects</returns>
        /// <exception cref="System.Exception">If the Host's id is a negative number</exception>
        Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id);
        /// <summary>
        /// Get a list of Residence objects via Repository
        /// </summary>
        /// <returns>A list of Residence objects</returns>
        Task<IList<Residence>> GetAvailableResidencesAsync();
        /// <summary>
        /// Update a Residence object via Repository
        /// </summary>
        /// <param name="residence">The updated Residence</param>
        /// <returns>Updated Residence object</returns>
        /// <exception cref="System.ArgumentException">If the start and end date is null</exception>
        /// <exception cref="System.ArgumentException">If the start and end date is earler than today's date</exception>
        /// <exception cref="System.ArgumentException">If the start date is earlier that the end date</exception>
        /// <exception cref="System.ArgumentException">If the Residence is null</exception>
        /// <exception cref="System.ArgumentException">If the Residence's id is a negative number</exception>
        /// <exception cref="System.ArgumentException">If the Residence's description is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's type is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's price per night is a negative number</exception>
        /// <exception cref="System.ArgumentException">If the Residence's max number of guests is a negative number</exception>
        /// <exception cref="System.ArgumentException">If the Residence's facilities are null</exception>
        /// <exception cref="System.ArgumentException">If the Residence's facilities' id are negative numbers</exception>
        /// <exception cref="System.ArgumentException">If the Residence's facilities' name is null or empty string</exception>
        /// <exception cref="System.ArgumentException">If the Residence's rules are null</exception>
        /// <exception cref="System.ArgumentException">If the Residence's rules' description is null or empty string</exception>
        Task<Residence> UpdateResidenceAsync(Residence residence);
        /// <summary>
        /// Delete a Residence object via Repository
        /// </summary>
        /// <param name="residence">The targeted Residence for deletion</param>
        /// <returns>The deleted Residence object</returns>
        /// <exception cref="System.ArgumentException">If the residence's id is a negative number</exception>
        Task<Residence> DeleteResidenceAsync(Residence residence);
    }
}