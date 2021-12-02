using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class Host : User
    {
        [JsonProperty("hostReviews", NullValueHandling = NullValueHandling.Ignore)]
        public IList<HostReview>? HostReviews { get; set; } = new List<HostReview>();
        [JsonProperty("profileImageUrl")]
        public string ProfileImageUrl { get; set; }
        [Required(ErrorMessage = "Please enter your CPR number")]
        [JsonProperty("cpr")]
        public string Cpr { get; set; }
        [JsonProperty("isApprovedHost")]
        public bool IsApprovedHost { get; set; } = false;
    }
}