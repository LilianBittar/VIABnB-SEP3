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
        
        [Required, Range(1, int.MaxValue, ErrorMessage ="Must be a positive number")]
        [JsonProperty("zipCode")]
        public int ZipCode { get; set; }
    }
}