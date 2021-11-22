using System;
using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class RentRequest
    {
        [Required, Range(1, Int32.MaxValue, ErrorMessage = "Id cannot be 0 or negative")]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }
        [Required]
        public RentRequest Status { get; set; }

        public Guest Guest { get; set; }
    }


    public enum RentRequestStatus
    {
        NotAnswered,
        NotApproved,
        Approved
    }
}