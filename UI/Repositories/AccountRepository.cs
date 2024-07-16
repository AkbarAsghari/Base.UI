using System.Reflection;
using UI.DTOs.Repositories.Accounts;
using UI.Enums;
using UI.Interfaces.Providers;
using UI.Interfaces.Repositories;

namespace UI.Repositories
{
    public class AccountRepository(IHttpServiceProvider _HttpServiceProvider) : IAccountRepository
    {
        const string APIController = "Account";
        public async Task<AuthUserDTO?> AuthenticateAsync(AuthenticateDTO model)
        {
            return await _HttpServiceProvider.Post<AuthenticateDTO, AuthUserDTO>($"{APIController}/AuthenticateAsync", model);
        }

        public async Task<bool> ChangeEmailAsync(string email)
        {
            return await _HttpServiceProvider.Put<bool>($"{APIController}/ChangeEmailAsync?email={email}");
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDTO model)
        {
            return await _HttpServiceProvider.Put<ChangePasswordDTO, bool>($"{APIController}/ChangePasswordAsync", model);
        }

        public Task<bool> ChangeUserRoleAsync(Guid userId, RolesEnum role)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ConfirmEmailWithTokenAsync(string token)
        {
            return await _HttpServiceProvider.Post<bool>($"{APIController}/");
        }

        public async Task<bool> DeactivateAccountAsync()
        {
            return await _HttpServiceProvider.Delete<bool>($"{APIController}/");

        }

        public async Task<bool> ForgetPasswordAsync(ForgetPasswordDTO model)
        {
            return await _HttpServiceProvider.Post<ForgetPasswordDTO, bool>($"{APIController}/", model);
        }

        public async Task<IEnumerable<UserDTO>?> GetAllAsync()
        {
            return await _HttpServiceProvider.Get<IEnumerable<UserDTO>>($"{APIController}/");
        }

        public async Task<UserDTO?> GetCurrentUserAsync()
        {
            return await _HttpServiceProvider.Get<UserDTO>($"{APIController}/GetCurrentUserAsync");
        }

        public async Task<UserDTO?> GetUserAsync(Guid userId)
        {
            return await _HttpServiceProvider.Get<UserDTO>($"{APIController}/");
        }

        public async Task<AuthUserDTO?> RegisterAsync(RegisterUserDTO model)
        {
            return await _HttpServiceProvider.Post<RegisterUserDTO, AuthUserDTO>($"{APIController}/RegisterAsync", model);
        }

        public async Task<bool> ResendConfirmEmailTokenAsync()
        {
            return await _HttpServiceProvider.Post<bool>($"{APIController}/");
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO model)
        {
            return await _HttpServiceProvider.Post<ResetPasswordDTO, bool>($"{APIController}/", model);
        }

        public async Task<bool> UpdateAsync(UpdateUserPersonalInfoDTO model)
        {
            return await _HttpServiceProvider.Put<UpdateUserPersonalInfoDTO, bool>($"{APIController}/", model);
        }

        public async Task<bool> UpdateUsernameAsync(string? username)
        {
            return await _HttpServiceProvider.Put<bool>($"{APIController}/UpdateUsernameAsync?username={username}");
        }

        public async Task<int> UsersCountAsync()
        {
            return await _HttpServiceProvider.Get<int>($"{APIController}/");
        }
    }
}
