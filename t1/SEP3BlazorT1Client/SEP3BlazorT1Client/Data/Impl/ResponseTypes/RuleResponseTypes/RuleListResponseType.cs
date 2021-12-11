using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.RuleResponseTypes
{
    public class RuleListResponseType
    {
        [JsonProperty("allRulesByResidenceId")] public IEnumerable<Rule> Rules { get; set; }
    }
}