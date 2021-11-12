using System.ComponentModel.DataAnnotations;

namespace SEP3BlazorT1Client.Models
{
    public class GuestRegistrationRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StudentNumber { get; set; }
        [Required]
        public string StudentIdImage { get; set; }
        [Required]
        public RequestStatus Status { get; set; } = RequestStatus.NotAnswered ;
    }
}