using System.ComponentModel.DataAnnotations;

namespace articles_app.Models
{
    public class RegisterRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
