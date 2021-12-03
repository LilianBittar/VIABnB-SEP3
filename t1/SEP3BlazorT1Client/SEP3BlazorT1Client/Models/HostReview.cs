using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class HostReview
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
        [JsonProperty("viaId")]
        public int ViaId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}