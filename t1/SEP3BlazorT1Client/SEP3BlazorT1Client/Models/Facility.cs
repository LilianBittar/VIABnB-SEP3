using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Facility
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}