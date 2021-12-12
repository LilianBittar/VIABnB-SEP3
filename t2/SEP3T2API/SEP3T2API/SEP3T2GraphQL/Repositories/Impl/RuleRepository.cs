using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;


namespace SEP3T2GraphQL.Repositories.Impl
{
    public class RuleRepository : IRuleRepository
    {
        private const string Uri = "http://localhost:8080";
        private readonly HttpClient _client;

        public RuleRepository()
        {
            _client = new HttpClient();
        }

        public async Task<Rule> CreateResidenceRuleAsync(Rule rule)
        {
            var ruleAsJson = JsonSerializer.Serialize(rule, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(ruleAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{Uri}/rule/{rule.ResidenceId}", content);
            if (!response.IsSuccessStatusCode)
                await HandleErrorResponse(response);

            var newRule = JsonSerializer.Deserialize<Rule>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return newRule;
        }

        public async Task<IEnumerable<Rule>> GetAllRulesByResidenceIdAsync(int residenceId)
        {
            var response = await _client.GetAsync($"{Uri}/rule/{residenceId}");
            await HandleErrorResponse(response);
            var result = await response.Content.ReadAsStringAsync();
            var rulesToReturn = JsonSerializer.Deserialize<List<Rule>>(result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return rulesToReturn;
        }

        public async Task<Rule> UpdateResidenceRuleAsync(Rule rule, string description)
        {
            var ruleAsJson = JsonSerializer.Serialize(rule, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(ruleAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync($"{Uri}/rule/{description}/{rule.ResidenceId}", content);
            await HandleErrorResponse(response);
            var newRule = JsonSerializer.Deserialize<Rule>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return newRule;
        }

        public async Task<Rule> DeleteRuleAsync(Rule rule)
        {
            var ruleAsJson = JsonSerializer.Serialize(rule, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var response = await _client.DeleteAsync($"{Uri}/rule/{rule.Description}/{rule.ResidenceId}");
            await HandleErrorResponse(response);
            
            return rule;
        }
        
        private static async Task HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync()+" " + response.StatusCode);
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}