using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP3BlazorT1Client.Models
{
    public class Guest : Host
    {
        [Required]
        public int ViaId { get; set; }
        public IList<GuestReview> GuestReviews { get; set; } = new List<GuestReview>();
    }
}