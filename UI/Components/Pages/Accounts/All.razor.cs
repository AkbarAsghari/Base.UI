
using Microsoft.AspNetCore.Components;
using UI.Interfaces.Repositories;

namespace UI.Components.Pages.Accounts;

partial class All
{
    [Inject] IAccountRepository _AccountRepository { get; set; }


    IEnumerable<UserDTO>? _AllUsers { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _AllUsers = await _AccountRepository.GetAllAsync();
    }
}
