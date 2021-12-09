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
        [JsonProperty("text")]
        public string Text { get; set; }
        [Required]
        [JsonProperty("hostEmail")]
        public string HostEmail { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [JsonProperty("guestId")]
        public int GuestId { get; set; }
        [Required]
        [JsonProperty("hostId")]
        public int HostId { get; set; }
    }
}