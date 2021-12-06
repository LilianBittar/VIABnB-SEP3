using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public int ZipCode { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj==null || !(obj.GetType() == typeof(City)))
            {
                return false; 
            }

            var other = (City) obj;
            return other.CityName == this.CityName && other.ZipCode == this.ZipCode; 
        }
    }
}