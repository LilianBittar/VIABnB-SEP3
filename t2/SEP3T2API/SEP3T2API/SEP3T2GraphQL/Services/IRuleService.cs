using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IRuleService
    {
        Task<Rule> CreateResidenceRule(Rule rule);
        Task<IEnumerable<Rule>> GetAllRulesByResidenceId(int residenceId);
        Task<Rule> UpdateRuleAsync(Rule rule, string description);
        Task<Rule> DeleteRule(Rule rule);
    }
}