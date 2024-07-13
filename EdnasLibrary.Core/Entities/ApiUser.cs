
using EdnasLibrary.Core.Enums;

namespace EdnasLibrary.Core.Entities
{
    public class ApiUser
    {
        public Guid Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
