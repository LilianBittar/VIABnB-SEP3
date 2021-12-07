using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IRuleService
    {
        Task<Rule> CreateRule(Rule rule);
        Task<IEnumerable<Rule>> GetAllRules();
        Task<Rule> UpdateRuleAsync(Rule rule);
        Task<Rule> DeleteRule(Rule rule);
    }
}