using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class GuestReview
    {
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [Required]
        [JsonProperty("host")]
        public Host Host { get; set; }
        
    }
}