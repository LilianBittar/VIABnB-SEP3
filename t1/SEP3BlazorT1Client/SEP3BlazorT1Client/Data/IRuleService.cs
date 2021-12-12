using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IRuleService
    {
        /// <summary>
        /// Create a new Rule object via repository
        /// </summary>
        /// <param name="rule">The new Rules object</param>
        /// <returns>The newly created Rule object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Rule> CreateResidenceRuleAsync(Rule rule);

        /// <summary>
        /// Get a list of Rule object based on the given parameter via repository
        /// </summary>
        /// <param name="residenceId">The targeted Rule's Residence's id</param>
        /// <returns>A list of Rule objects</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IEnumerable<Rule>> GetAllRulesByResidenceIdAsync(int residenceId);
        /// <summary>
        /// Delete a Rule object via repository
        /// </summary>
        /// <param name="rule">The targeted Rule object for deletion</param>
        /// <returns>The deleted Rule object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<Rule> DeleteRuleAsync(Rule rule);
    }
}