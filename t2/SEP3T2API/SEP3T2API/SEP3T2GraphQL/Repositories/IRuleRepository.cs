
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IRuleRepository
    {
        Task<Rule> CreateResidenceRule(Rule rule);
        Task<IEnumerable<Rule>> GetAllRulesByResidenceId(int residenceId);
        Task<Rule> UpdateResidenceRule(Rule rule, string description);
        Task<Rule> DeleteRule(Rule rule);
    }
}