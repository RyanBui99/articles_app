using System;
using System.ComponentModel.DataAnnotations;

namespace articles_app.Models
{
    /// <summary>
    /// Model for login, sets user email and password
    /// </summary>
    public class LoginRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
