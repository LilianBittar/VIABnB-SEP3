using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SEP3BlazorT1Client.Models
{
    public class Rule
    {
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}