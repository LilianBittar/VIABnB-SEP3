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
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }
        [JsonProperty("city")]
        
        [Required] public City City { get; set; }
        public override string ToString()
        {
            return $"{StreetName}-{StreetNumber}-{HouseNumber}";
                
        }
    }
}