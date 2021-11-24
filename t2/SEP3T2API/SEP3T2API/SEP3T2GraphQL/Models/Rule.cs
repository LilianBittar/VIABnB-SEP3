using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Rule
    {
        [Required]
        public string Description { get; set; }
    }
}