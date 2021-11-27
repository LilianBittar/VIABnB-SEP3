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
        Task<Residence> GetResidenceByIdAsync(int id);
        Task<Residence>  CreateResidenceAsync(Residence residence); 
        Task<IList<Residence>> GetAllRegisteredResidencesByHostIdAsync(int id);
        Task<IList<Residence>> GetAvailableResidencesAsync(); 
        
    }
}