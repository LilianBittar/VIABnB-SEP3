using System.ComponentModel.DataAnnotations;

namespace SEP3BlazorT1Client.Models
{
    public class HostRegistrationRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PersonalImage { get; set; }
        [Required]
        public string CprNumber { get; set; }
        public Host Host { get; set; }

        [Required] public RequestStatus Status { get; set; } = RequestStatus.NotAnswered;
    }
}