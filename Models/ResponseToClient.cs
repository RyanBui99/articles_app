using System.Collections.Generic;

namespace articles_app.Models
{
    public class ResponseToClient
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
    }
}
