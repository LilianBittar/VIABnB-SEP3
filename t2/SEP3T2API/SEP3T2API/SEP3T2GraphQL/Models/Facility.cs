using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Facility
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}