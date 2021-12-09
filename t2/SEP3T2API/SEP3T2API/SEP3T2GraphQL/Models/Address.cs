using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Address
    {
        [Required] public int Id { get; set; }
        [Required] public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        [Required] public string StreetNumber { get; set; }
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