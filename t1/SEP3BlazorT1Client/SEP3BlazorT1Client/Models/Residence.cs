using System.Collections.Generic;
using System.Text.Json;

namespace SEP3BlazorT1Client.Models
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
        
        public string photo { get; set; }
        public IList<Rule> Rules { get; set; } = new List<Rule>();
        public IList<Facility> Facilities { get; set; } = new List<Facility>();

        public override string ToString()
        {
            return JsonSerializer.Serialize(this); 
        }

        
    }
}