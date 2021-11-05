using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class ResidenceInput
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("address")]
        public Address address { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("averageRating")]
        public float AverageRating { get; set; }
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
        [JsonProperty("pricePerNight")]
        public float PricePerNight { get; set; }
        [JsonProperty("rules")]
        public List<Rule> Rules { get; set; }
        [JsonProperty("facilities")]
        public List<Facility> Facilities { get; set; }
        [JsonProperty("availableFrom")]
        public DateTime AvailableFrom { get; set; } 
        [JsonProperty("availableTo")]
        public DateTime AvailableTo { get; set; } 
        
        
        
        
        
        
        
                
        
        
        
    }
}