using System;
namespace articles_app.Models
{
    /// <summary>
    /// Model for login
    /// </summary>
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
