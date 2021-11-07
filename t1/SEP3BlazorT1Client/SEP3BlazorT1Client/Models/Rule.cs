using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SEP3BlazorT1Client.Models
{
    public class Rule
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}