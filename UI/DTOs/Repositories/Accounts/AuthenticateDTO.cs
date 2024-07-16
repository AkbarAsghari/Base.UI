using System.ComponentModel.DataAnnotations;

namespace UI.DTOs.Repositories.Accounts
{
    public class AuthenticateDTO
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
