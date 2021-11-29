using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IRuleService
    {
        Task<Rule> CreateRuleAsynce(Rule rule);
        Task<IEnumerable<Rule>> GetAllRulesAsynce();
    }
}