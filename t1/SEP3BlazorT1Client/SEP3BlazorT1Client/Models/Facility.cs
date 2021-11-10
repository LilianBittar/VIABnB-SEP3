using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Facility
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}