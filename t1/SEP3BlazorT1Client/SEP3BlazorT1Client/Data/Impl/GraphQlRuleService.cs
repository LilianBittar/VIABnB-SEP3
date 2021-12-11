using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.RuleResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlRuleService : IRuleService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};
        public async Task<Rule> CreateResidenceRuleAsync(Rule rule)
        {
            var mutation = new GqlQuery()
            {
                Query = @"mutation($newRule:RuleInput){
                              createNewResidenceRule(rule:$newRule){
                                description
                                residenceId
                              }
                            }",
                Variables = new {newRule = rule}
            };
            var response = await _client.PostQueryAsync<CreateRuleResponseType>(mutation);
            HandleErrorResponse(response);
            return response.Data.Rule;
        }

        public async Task<IEnumerable<Rule>> GetAllRulesByResidenceIdAsync(int residenceId)
        {
            var query = new GqlQuery()
            {
                Query = @"query ($id:Int!){
                              allRulesByResidenceId(residenceId: $id) {
                                description
                                residenceId
                              }
                            }
                            ",
                Variables = new {id = residenceId}
            };
            var response = await _client.PostQueryAsync<RuleListResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.Rules;
        }

        public async Task<Rule> UpdateRuleAsync(Rule rule, string description)
        {
            var mutation = new GqlQuery()
            {
                Query = @"mutation($newRule:RuleInput, $ruleDes){
                              updateResidenceRule(rule:$newRule, description:$ruleDes){
                                description
                                residenceId
                              }
                            }",
                Variables = new {newRule = rule, ruleDes = description}
            };
            var response = await _client.PostQueryAsync<UpdateRuleResponseType>(mutation);
            HandleErrorResponse(response);
            return response.Data.Rule;
        }

        public async Task<Rule> DeleteRuleAsync(Rule rule)
        {
            var mutation = new GqlQuery()
            {
                Query = @"mutation($dRule:RuleInput){
                              deleteRule(rule:$dRule){
                                description
                                residenceId
                              }
                            }",
                Variables = new {dRule = rule}
            };
            var response = await _client.PostQueryAsync<DeleteRuleResponseType>(mutation);
            HandleErrorResponse(response);
            return response.Data.Rule;
        }
        
        private static void HandleErrorResponse<T>(GqlRequestResponse<T> response)
        {
            if (response.Errors != null)
            {
                // String manipulation to seperate the Error message from the sample error response. 
                Console.WriteLine(JsonConvert.SerializeObject(response.Errors));
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors).Split(",")[4]
                    .Split(":")[2]);
            }
        }
    }
}