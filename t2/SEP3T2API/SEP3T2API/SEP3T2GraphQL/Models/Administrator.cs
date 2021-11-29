using System.ComponentModel.DataAnnotations;

namespace SEP3T2GraphQL.Models
{
    public class Administrator
    {
        [Required] 
        public int Id { get; set; }
        [Required] 
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required] 
        public string PhoneNumber { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}