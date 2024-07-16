using Microsoft.AspNetCore.Components;
using UI.Interfaces.Providers;

namespace UI.Components.Pages.Accounts;

partial class SignOut
{
    [Inject] IAuthenticationProvider _AuthenticationProvider { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await _AuthenticationProvider.Logout();
        _NavigationManager.NavigateTo("/");
    }
}
