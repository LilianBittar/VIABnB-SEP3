using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Residence
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        public double AverageRating { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public double PricePerNight { get; set; }
        [Required]
        public IList<Rule> Rules { get; set; } = new List<Rule>();
        [Required]
        public IList<Facility> Facilities { get; set; } = new List<Facility>(); 
        public string ImageUrl { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
    }
}