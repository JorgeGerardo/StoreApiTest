using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bussiness.Models
{
    public class User : BaseModel
    {
        [EmailAddress]
        [JsonPropertyOrder(-1)]
        public required string Email { get; set; }
        public required string HashPassword { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
        public int? CustomerId { get; set; }

        public required Role Role { get; set; }
    }

    public class UserLoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public enum Role
    {
        Customer, Admin
    }
}
