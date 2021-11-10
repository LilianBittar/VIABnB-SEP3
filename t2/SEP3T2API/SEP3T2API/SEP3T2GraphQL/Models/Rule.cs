using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Rule
    {
        [Required]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}