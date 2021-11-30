using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;

// TODO: Possibly change data type of PricerPerNight to support bigger prices.
namespace SEP3BlazorT1Client.Models
{   
    public class Residence
    {   [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("address")]
        
        public Address Address { get; set; }
        [JsonProperty("description")]
        [Required]
        public string Description { get; set; }
        [JsonProperty("type")]
        [Required (AllowEmptyStrings =false)]
        [DisplayFormat(ConvertEmptyStringToNull =false)]
        public string Type { get; set; }
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
        [Required]
        [JsonProperty("pricePerNight")]
        [Range(0, int.MaxValue)]
        public double PricePerNight { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [Required]
        [JsonProperty("rules")]
        public IList<Rule> Rules { get; set; } = new List<Rule>();
        [Required]
        [JsonProperty("facilities")]
        public IList<Facility> Facilities { get; set; } = new List<Facility>();
        [JsonProperty("availableFrom")]
        public DateTime? AvailableFrom { get; set; }
        [JsonProperty("availableTo")]
        public DateTime? AvailableTo { get; set; }
        [Required, Range(1, int.MaxValue)]
        [JsonProperty("maxNumberOfGuests")]
        public int MaxNumberOfGuests { get; set; }
        [JsonProperty("host")]
        public Host Host { get; set; }
        [JsonProperty("residenceReviews")]
        public IEnumerable<ResidenceReview> ResidenceReviews { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); 
        }

        public double GetAverageRating()
        {
            if (!ResidenceReviews.Any() || ResidenceReviews == null)
            {
                return 0; 
            }

            double sum = ResidenceReviews.Sum(residenceReview => residenceReview.Rating);

            return sum / ResidenceReviews.Count();
        }
        
    }
}