using Microsoft.AspNetCore.Components;
using UI.Interfaces.Providers;
using UI.Interfaces.Repositories;

namespace UI.Components.Pages.Accounts;

partial class Register
{
    [Inject] IAccountRepository _AccountRepository { get; set; }
    [Inject] IAuthenticationProvider _AuthenticationProvider { get; set; }
    [Inject] ISnackbar _Snachbar { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    RegisterUserDTO _RegisterUserDTO = new();

    public async Task RegisterUser()
    {
        if (!_RegisterUserDTO.Password.Equals(_RegisterUserDTO.ConfirmPassword))
        {
            _Snachbar.Add("رمز عبور و تکرار رمز عبور برابر نیست", Severity.Warning);
            return;
        }

        var response = await _AccountRepository.RegisterAsync(_RegisterUserDTO);

        if (response != null)
        {
            await _AuthenticationProvider.Login(response.Token);
            _NavigationManager.NavigateTo("/Dashboard");
        }
    }
}
