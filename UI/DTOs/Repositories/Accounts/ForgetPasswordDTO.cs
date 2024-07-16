using System.ComponentModel.DataAnnotations;

namespace UI.DTOs.Repositories.Accounts
{
    public class ForgetPasswordDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
