using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IRuleService
    {
        /// <summary>
        /// create a new rule and stores it in the system
        /// </summary>
        /// <param name="rule"></param>
        /// <returns> the created rule</returns>
        Task<Rule> CreateResidenceRuleAsync(Rule rule);

        /// <summary>
        /// method in order to retrieve all the rules stored in the system
        /// </summary>
        /// <param name="residenceId"></param>
        /// <returns> a list with all the rules </returns>
        Task<IEnumerable<Rule>> GetAllRulesByResidenceIdAsync(int residenceId);

        Task<Rule> UpdateRuleAsync(Rule rule, string description);
        Task<Rule> DeleteRuleAsync(Rule rule);
    }
}