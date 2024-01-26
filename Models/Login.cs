 
using System.ComponentModel.DataAnnotations;

namespace EmailFlowApi.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; } // Use a numeric or GUID primary key

        [Required]
        [EmailAddress]
        [MaxLength(255)] // Adjust the max length as needed
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
