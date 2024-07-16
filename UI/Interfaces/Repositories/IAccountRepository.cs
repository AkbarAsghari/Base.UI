﻿using UI.DTOs.Repositories.Accounts;
using UI.Enums;

namespace UI.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<AuthUserDTO?> AuthenticateAsync(AuthenticateDTO model);
        Task<bool> ForgetPasswordAsync(ForgetPasswordDTO model);
        Task<bool> ResetPasswordAsync(ResetPasswordDTO model);
        Task<bool> ChangePasswordAsync(ResetPasswordDTO model);
        Task<bool> ChangeUserRoleAsync(Guid userId, RolesEnum role);
        Task<AuthUserDTO?> RegisterAsync(RegisterUserDTO model);
        Task<bool> ConfirmEmailWithTokenAsync(string token);
        Task<bool> ResendConfirmEmailTokenAsync();
        Task<bool> UpdateAsync(UpdateUserPersonalInfoDTO model);
        Task<bool> UpdateUsernameAsync(string? username);
        Task<bool> ChangeEmailAsync(string email);
        Task<UserDTO?> GetCurrentUserAsync();
        Task<int> UsersCountAsync();
        Task<UserDTO?> GetUserAsync(Guid userId);
        Task<IEnumerable<UserDTO>?> GetAllAsync();
        Task<bool> DeactivateAccountAsync();
    }
}
