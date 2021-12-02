using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class GuestReview
    {
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("rating")]
        public double Rating { get; set; }
        public string Text { get; set; }
        [Required]
        [JsonProperty("host")]
        public Host host { get; set; }
    }
}