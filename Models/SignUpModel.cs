 using System.ComponentModel.DataAnnotations;

namespace EmailFlowApi.Models
{
    public class SignUpModel
    {
        [Required]
        [EmailAddress]
        public string Email{ get; set; }

      
        [Required]
        [StringLength(100, MinimumLength =  6)]
        public string Password { get; set; }
    }
}
