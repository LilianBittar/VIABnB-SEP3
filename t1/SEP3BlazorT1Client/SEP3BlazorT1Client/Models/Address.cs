using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Address
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required (AllowEmptyStrings =false)]
        [DisplayFormat(ConvertEmptyStringToNull =false)]
        [JsonProperty("streetName")]
        
        public string StreetName { get; set; }
        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }
        [Required (AllowEmptyStrings =false)]
        [DisplayFormat(ConvertEmptyStringToNull =false)]
        [JsonProperty("cityName")]
        public string CityName { get; set; }
        [Required (AllowEmptyStrings =false)]
        [DisplayFormat(ConvertEmptyStringToNull =false)]
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