using System.ComponentModel.DataAnnotations;

namespace SEP3BlazorT1Client.Models
{
    public class GuestRegistrationRequest
    {
        [Required]
        public int Id { get; set; }
        [Required, Range(0, 999999)]
        public int StudentNumber { get; set; }
        [Required]
        public Host Host { get; set; }
        [Required]
        public string StudentIdImage { get; set; }
        [Required]
        public RequestStatus Status { get; set; } = RequestStatus.NotAnswered ;
    }
}