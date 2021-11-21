using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Guest : Host
    {
        [Required]
        [JsonProperty("viaId")]
        public int ViaId { get; set; }
        [JsonProperty("guestReviews")]
        public IList<GuestReview>? GuestReviews { get; set; } = new List<GuestReview>();
        [JsonProperty("isApprovedGuest")]
        public bool IsApprovedGuest { get; set; } = false; 
    }
}