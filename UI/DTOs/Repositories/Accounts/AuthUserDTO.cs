namespace UI.DTOs.Repositories.Accounts
{
    public class AuthUserDTO
    {
        public AuthUserDTO(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}
