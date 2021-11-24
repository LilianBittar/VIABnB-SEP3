using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Guest : Host
    {
        [Required] 
        public int ViaId { get; set; }
        public IList<GuestReview>? GuestReviews { get; set; } = new List<GuestReview>();
        public bool IsApprovedGuest { get; set; } = false; 
    }
}