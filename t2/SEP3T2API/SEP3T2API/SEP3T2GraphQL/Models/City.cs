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
    }
}