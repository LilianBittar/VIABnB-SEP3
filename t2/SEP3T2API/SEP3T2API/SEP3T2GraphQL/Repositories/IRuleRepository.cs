using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IRuleRepository
    {
        /// <summary>
        /// Create a new Rule object via API
        /// </summary>
        /// <param name="rule">The new Rules object</param>
        /// <returns>The newly created Rule object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Rule> CreateResidenceRuleAsync(Rule rule);
        /// <summary>
        /// Get a list of Rule object based on the given parameter via API
        /// </summary>
        /// <param name="residenceId">The targeted Rule's Residence's id</param>
        /// <returns>A list of Rule objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<IEnumerable<Rule>> GetAllRulesByResidenceIdAsync(int residenceId);
        /// <summary>
        /// Update a Rule object via API
        /// </summary>
        /// <param name="rule">The updated Rule</param>
        /// <param name="description">The targeted Rule's description</param>
        /// <returns>The updated Rule object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Rule> UpdateResidenceRuleAsync(Rule rule, string description);
        /// <summary>
        /// Delete a Rule object via API
        /// </summary>
        /// <param name="rule">The targeted Rule object for deletion</param>
        /// <returns>The deleted Rule object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        Task<Rule> DeleteRuleAsync(Rule rule);
    }
}