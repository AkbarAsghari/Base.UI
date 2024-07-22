using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using static MudBlazor.Colors;

namespace UI.Components.Custom;

partial class BaseButton
{
    [Parameter]
    public EditContext EditContext { get; set; }
    protected override async Task OnClickHandler(MouseEventArgs ev)
    {
        base.Disabled = true;

        if (EditContext == null)
            await OnClick.InvokeAsync();
        else if (EditContext.Validate())
            await OnClick.InvokeAsync();

        base.Disabled = false;
        await InvokeAsync(() => StateHasChanged());
    }
}
