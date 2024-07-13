using EdnasLibrary.Core.Enums;

namespace EdnasLibrary.Core.Dtos
{
    public class JwtTokenUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
    }
}
