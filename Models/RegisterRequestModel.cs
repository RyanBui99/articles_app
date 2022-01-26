using System.ComponentModel.DataAnnotations;

namespace articles_app.Models
{
    public class RegisterRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
