using Microsoft.AspNetCore.Components;
using UI.Interfaces.Providers;
using UI.Interfaces.Repositories;

namespace UI.Components.Pages.Accounts;

partial class Login
{
    [Inject] IAccountRepository _AccountRepository { get; set; }
    [Inject] IAuthenticationProvider _AuthenticationProvider { get; set; }
    [Inject] ISnackbar _Snackbar { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public string? RedirectTo { get; set; }
    protected override void OnInitialized()
    {
        if (!String.IsNullOrWhiteSpace(RedirectTo) && !RedirectTo.ToLower().EndsWith("dashboard"))
            _Snackbar.Add("برای ادامه ابتدا باید وارد شوید", Severity.Info);
    }

    AuthenticateDTO _AuthenticateDTO = new();

    MudForm _Form;
    public async Task Authenticate()
    {
        await _Form.Validate();

        if (!_Form.IsValid)
        {
            return;
        }

        var response = await _AccountRepository.AuthenticateAsync(_AuthenticateDTO);

        if (response != null)
        {
            await _AuthenticationProvider.Login(response.Token);
            if (String.IsNullOrEmpty(RedirectTo))
            {
                _NavigationManager.NavigateTo("/Dashboard");
            }
        }
    }
}
