using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class ResidenceReview
    {
        [Required]
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("reviewText")]
        public string ReviewText { get; set; }
        [JsonProperty("guest")]
        [Required]
        public Guest Guest { get; set; }
    }
}