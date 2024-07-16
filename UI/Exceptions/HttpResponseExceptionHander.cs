using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Net;
using System.Text.Json;
using UI.DTOs.Repositories.Exceptions;

namespace UI.Exceptions
{
    public class HttpResponseExceptionHander(NavigationManager _NavigationManager, ISnackbar _Snackbar)
    {
        public async Task HandlerExceptionAsync(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if (await CheckIsReponseExceptionHandler(httpResponseMessage))
                    return;

                var statusCode = httpResponseMessage.StatusCode;

                switch (statusCode)
                {
               
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.Conflict:
                    case HttpStatusCode.TooManyRequests:
                        break;
                    case HttpStatusCode.Unauthorized:
                        _NavigationManager.NavigateTo($"/Accounts/Login");
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

        private async Task<bool> CheckIsReponseExceptionHandler(HttpResponseMessage httpResponseMessage)
        {
            string content = await httpResponseMessage.Content!.ReadAsStringAsync();
            if (String.IsNullOrEmpty(content))
                return false;

            var error = JsonSerializer.Deserialize<ExceptionDTO>(content!, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (error != null)
            {
                _Snackbar.Add(error.Key, Severity.Error);
                return true;
            }
            return false;
        }
    }
}
