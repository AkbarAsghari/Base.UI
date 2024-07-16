using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net;

namespace UI.Exceptions
{
    public class HttpResponseExceptionHander(NavigationManager _NavigationManager, ISnackbar _Snackbar)
    {
        public void HandlerExceptionAsync(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                //if (await ShowToastMessageAsync(httpResponseMessage))
                //    return;

                var statusCode = httpResponseMessage.StatusCode;

                switch (statusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        if (!_NavigationManager.Uri.ToLower().EndsWith("/Accounts/Login"))
                            _NavigationManager.NavigateTo($"/Accounts/Login");
                        break;
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.Conflict:
                    case HttpStatusCode.TooManyRequests:
                        break;
                    case HttpStatusCode.NotFound:
                        _NavigationManager.NavigateTo("/Errors/404", true);
                        break;
                    case HttpStatusCode.InternalServerError:
                        _NavigationManager.NavigateTo("/Errors/500", true);
                        break;
                    case HttpStatusCode.ServiceUnavailable:
                        _NavigationManager.NavigateTo("/Errors/503", true);
                        break;
                }
            }
        }
    }
}
