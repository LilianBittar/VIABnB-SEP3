using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP3BlazorT1Client.Models
{
    public class Host
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your lastname")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter your E-mail address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
        public IList<HostReview> HostReviews { get; set; } = new List<HostReview>();
        [Required]
        public string Cpr { get; set; }

        public string ProfileImageUrl { get; set; }
        public bool IsApprovedHost { get; set; } = false;

        public override string ToString()
        {
            return
                $"{Id} {FirstName} {LastName} {PhoneNumber} {Email} {Password} {Cpr} {ProfileImageUrl} {IsApprovedHost}";
        }
    }
}