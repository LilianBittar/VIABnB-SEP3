using System.Collections.Generic;

namespace SEP3T2GraphQL.Models
{
    public class Residence
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal AverageRating { get; set; }
        public bool IsAvailable { get; set; }
        public decimal PricePerNight { get; set; }
        public IList<Rule> Rules { get; set; } = new List<Rule>();
        public IList<Facility> Facilities { get; set; } = new List<Facility>(); 
    }
}