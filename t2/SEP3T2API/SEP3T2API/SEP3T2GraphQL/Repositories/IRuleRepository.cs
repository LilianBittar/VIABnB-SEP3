
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IRuleRepository
    {
        Task<Rule> CreateRule(Rule rule);
        Task<IEnumerable<Rule>> GetAllRules();
    }
}