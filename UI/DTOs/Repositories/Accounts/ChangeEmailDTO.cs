using System.ComponentModel.DataAnnotations;

namespace UI.DTOs.Repositories.Accounts
{
    public class ChangeEmailDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
