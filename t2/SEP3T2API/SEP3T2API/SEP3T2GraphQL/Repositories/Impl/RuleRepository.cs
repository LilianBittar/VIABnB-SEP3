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
        private string uri = "http://localhost:8080";
        private readonly HttpClient client = new HttpClient();
        
        public async Task<Rule> CreateRule(Rule rule)
        {
            var ruleAsJson = JsonSerializer.Serialize(rule, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            HttpContent content = new StringContent(ruleAsJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{uri}/rule", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var newRule = JsonSerializer.Deserialize<Rule>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return newRule;
        }

        public async Task<IEnumerable<Rule>> GetAllRules()
        {
            var response = await client.GetAsync($"{uri}/rules");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
            var result = await response.Content.ReadAsStringAsync();
            var rulesToReturn = JsonSerializer.Deserialize<List<Rule>>(result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return rulesToReturn;
        }
    }
}