using Microsoft.AspNetCore.Components;
using UI.Interfaces.Repositories;

namespace UI.Components.Pages.Accounts;

partial class Login
{
    [Inject] IAccountRepository _AccountRepository { get; set; }

    AuthenticateDTO _AuthenticateDTO = new();

    MudForm _Form;
    public async Task Authenticate()
    {
        await _Form.Validate();

        if (!_Form.IsValid)
        {
            return;
        }

        var response =  await _AccountRepository.AuthenticateAsync(_AuthenticateDTO);

        if (response != null)
        {
            
        }
    }
}
