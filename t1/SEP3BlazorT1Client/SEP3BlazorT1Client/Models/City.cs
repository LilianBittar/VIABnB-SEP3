using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class City
    {
        [JsonProperty("id")]
        [Required]
        public int CityId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [JsonProperty("cityName")]
        [DisplayFormat(ConvertEmptyStringToNull =false)]
        public string CityName { get; set; }
        
        [Required, Range(1000, 9999, ErrorMessage ="Invalid Zip Code")]
        [JsonProperty("zipCode")]
        public int ZipCode { get; set; }
    }
}