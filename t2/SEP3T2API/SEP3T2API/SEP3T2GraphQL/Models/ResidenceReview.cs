using System;

namespace SEP3T2GraphQL.Models
{
    public class ResidenceReview
    {
        public double Rating { get; set; }
        public string ReviewText { get; set; }
        public int GuestViaId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}