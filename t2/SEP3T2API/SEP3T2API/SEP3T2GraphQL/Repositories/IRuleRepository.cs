using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IRuleRepository
    {
        Task<Rule> CreateResidenceRuleAsync(Rule rule);
        Task<IEnumerable<Rule>> GetAllRulesByResidenceIdAsync(int residenceId);
        Task<Rule> UpdateResidenceRuleAsync(Rule rule, string description);
        Task<Rule> DeleteRuleAsync(Rule rule);
    }
}