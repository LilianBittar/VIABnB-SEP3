using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Address
    {
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("streetName")]
        public string StreetName { get; set; }
        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }
        [Required]
        [JsonProperty("cityName")]
        public string CityName { get; set; }
        [Required]
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage ="Must be a positive number")]
        [JsonProperty("zipCode")]
        public int ZipCode { get; set; }

        public override string ToString()
        {
            return $"{StreetName}-{StreetNumber}-{HouseNumber}-{CityName}-{ZipCode}";
                
        }
    }
}