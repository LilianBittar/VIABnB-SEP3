using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Residence
    {   [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("averageRating")]
        public decimal AverageRating { get; set; }
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
        [JsonProperty("pricePerNight")]
        public decimal PricePerNight { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("rules")]
        public IList<Rule> Rules { get; set; } = new List<Rule>();
        [JsonProperty("facilities")]
        public IList<Facility> Facilities { get; set; } = new List<Facility>();
        [JsonProperty("availableFrom")]
        public DateTime AvailableFrom { get; set; }
        [JsonProperty("availableTo")]
        public DateTime AvailableTo { get; set; }
        
        
        

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); 
        }

        
    }
}