using System.Collections.Generic;

namespace BograczApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; } = "User";
        public List<Order> Orders { get; set; } = new();
    }
}
