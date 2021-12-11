using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class Address
    {
        [JsonProperty("id")]
        [Required] public int Id { get; set; }
        [JsonProperty("streetName")]
        [Required] public string StreetName { get; set; }
        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }
        [JsonProperty("streetNumber")]
        [Required] public string StreetNumber { get; set; }
        [JsonProperty("city")]
        [Required] public City City { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj.GetType() == typeof(Address)))
            {
                return false;
            }

            var other = (Address) obj;
            return other.StreetName == this.StreetName && other.City.Equals(this.City) &&
                   other.HouseNumber == this.HouseNumber && other.StreetNumber == this.StreetNumber;
        }
    }
}