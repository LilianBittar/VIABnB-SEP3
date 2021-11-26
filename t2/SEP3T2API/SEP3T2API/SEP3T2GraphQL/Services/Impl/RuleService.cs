using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public class RuleService : IRuleService
    {
        private IRuleRepository _ruleRepository;

        public RuleService(IRuleRepository ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        public async Task<Rule> CreateRule(Rule rule)
        {
            var newRule = await _ruleRepository.CreateRule(rule);
            if (newRule == null)
            {
                throw new Exception("Rule can't be null");
            }

            return newRule;
        }

        public async Task<IEnumerable<Rule>> GetAllRules()
        {
            var ruleListToReturn = await _ruleRepository.GetAllRules();
            if (ruleListToReturn == null)
            {
                throw new Exception("Rule list can't be null");
            }

            return ruleListToReturn;
        }
    }
}