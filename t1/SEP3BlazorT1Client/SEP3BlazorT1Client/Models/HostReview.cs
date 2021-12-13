using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class HostReview
    {
        [Required]
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [Required]
        [JsonProperty("guestId")]
        public int GuestId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [JsonProperty("hostId")]
        public int HostId { get; set; }
    }
}