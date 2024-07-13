namespace EdnasLibrary.Core.Models
{
    public class JwtAuth
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }       
    }
}
