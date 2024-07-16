using Microsoft.AspNetCore.Components;
using UI.Interfaces.Repositories;

namespace UI.Components.Pages.Accounts;

partial class Register
{
    [Inject] IAccountRepository _AccountRepository { get; set; }
    [Inject] ISnackbar _Snachbar { get; set; }

    RegisterUserDTO _RegisterUserDTO = new();

    MudForm _Form;
    public async Task RegisterUser()
    {
        await _Form.Validate();

        if (!_Form.IsValid)
        {
            return;
        }

        if (!_RegisterUserDTO.Password.Equals(_RegisterUserDTO.ConfirmPassword))
        {
            _Snachbar.Add("رمز عبور و تکرار رمز عبور برابر نیست", Severity.Warning);
            return;
        }

        var response = await _AccountRepository.RegisterAsync(_RegisterUserDTO);

        if (response != null)
        {

        }
    }
}
