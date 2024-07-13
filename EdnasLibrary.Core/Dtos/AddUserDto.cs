using EdnasLibrary.Core.Enums;

namespace EdnasLibrary.Core.Dtos
{
    public class AddUserDto : LoginUserDto
    {        
        public string CompleteName { get; set; }
        public RoleEnum Role { get; set; }        
    }
}
