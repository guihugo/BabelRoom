using Microsoft.AspNetCore.Identity;

namespace BabelRoomWebApplication.Models
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}