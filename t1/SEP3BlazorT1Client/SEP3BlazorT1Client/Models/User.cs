using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class User
    {
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your E-mail address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [JsonProperty("email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}