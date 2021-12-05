using System;
using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class ResidenceReview
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("reviewText")]
        public string ReviewText { get; set; }
        [JsonProperty("guestViaId")]
        public int GuestViaId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}