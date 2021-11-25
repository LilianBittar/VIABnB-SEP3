using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Administrator
    {
        [Required] 
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required] 
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [Required] 
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [Required] 
        [JsonProperty("email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required] 
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [Required] 
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}