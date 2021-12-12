using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IRuleService
    {
        Task<Rule> CreateResidenceRuleAsync(Rule rule);
        Task<IEnumerable<Rule>> GetAllRulesByResidenceIdAsync(int residenceId);
        Task<Rule> UpdateRuleAsync(Rule rule, string description);
        Task<Rule> DeleteRuleAsync(Rule rule);
    }
}