using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Guest : Host
    {
        [Required] 
        [Range(100000, 999999, ErrorMessage = "Invalid student number")]
        public int ViaId { get; set; }
        public IList<GuestReview> GuestReviews { get; set; } = new List<GuestReview>();
        public bool IsApprovedGuest { get; set; } = false; 
    }
}