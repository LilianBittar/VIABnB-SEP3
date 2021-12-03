using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class HostReview
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double Rating { get; set; }
        public string Text { get; set; }
        [Required]
        public int ViaId { get; set; }
    }
}