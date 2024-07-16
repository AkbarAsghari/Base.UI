using System.ComponentModel.DataAnnotations;

namespace UI.DTOs.Repositories.Accounts
{
    public class ChangePasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
