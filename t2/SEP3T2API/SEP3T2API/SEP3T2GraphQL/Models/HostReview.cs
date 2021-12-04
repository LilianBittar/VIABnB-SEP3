using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class HostReview
    {
        [Required]
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [Required]
        [JsonProperty("viaId")]
        public int ViaId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}