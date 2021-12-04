using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class GuestReview
    {
        [Required]
        [JsonProperty("rating")]
        public double Rating { get; set; }
        public string Text { get; set; }
        [Required]
        [JsonProperty("hostEmail")]
        public string HostEmail { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}