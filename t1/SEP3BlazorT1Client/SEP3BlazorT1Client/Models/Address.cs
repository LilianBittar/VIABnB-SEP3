using System.ComponentModel.DataAnnotations;

namespace SEP3BlazorT1Client.Models
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public int ZipCode { get; set; }
    }
}