using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required] public City City { get; set; }
    }
}