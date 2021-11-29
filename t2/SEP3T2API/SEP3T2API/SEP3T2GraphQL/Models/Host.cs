using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class Host
    {
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your firstname")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your lastname")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter your E-mail address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [JsonProperty("email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [JsonProperty("password")]
        public string Password { get; set; }
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