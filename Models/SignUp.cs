using System.ComponentModel.DataAnnotations;

namespace EmailFlowApi.Models
{
    public class SignUp
    {


        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
