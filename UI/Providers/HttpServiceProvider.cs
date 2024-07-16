using System.Net.Http;
using System.Text;
using System.Text.Json;
using UI.DTOs.Providers;
using UI.Exceptions;
using UI.Interfaces.Providers;

namespace UI.Providers
{
    public class HttpServiceProvider(HttpClient _HttpClient, HttpResponseExceptionHander _HttpResponseExceptionHander) : IHttpServiceProvider
    {
        string _BaseUrl = AppSettings.APIBaseAddress;

        private async Task<HttpResponseWraper<T?>> GenerateHttpResponseWraper<T>(HttpResponseMessage httpResponse)
        {
            if (!httpResponse.IsSuccessStatusCode)
            {
                _HttpResponseExceptionHander.HandlerExceptionAsync(httpResponse);
                return new HttpResponseWraper<T?>(default, false, httpResponse);
            }
            else
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();

                T? response;
                if (typeof(T) == typeof(String))
                {
                    response = (T)(object)responseString;
                }

                response = JsonSerializer.Deserialize<T>(responseString,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return new HttpResponseWraper<T?>(response,
                    httpResponse.IsSuccessStatusCode,
                    httpResponse);
            }
        }

        public StringContent GenerateStringContentFromObject<T>(T data)
        {
            return new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        }

        public async Task<HttpResponseWraper<TResponse?>> Delete<TResponse>(string url)
        {
            return await GenerateHttpResponseWraper<TResponse>(await _HttpClient.DeleteAsync(_BaseUrl + url));
        }

        public async Task<HttpResponseWraper<TResponse?>> Get<TResponse>(string url)
        {
            return await GenerateHttpResponseWraper<TResponse>(await _HttpClient.GetAsync(_BaseUrl + url));

        }

        public async Task<HttpResponseWraper<TResponse?>> Post<T, TResponse>(string url, T data)
        {
            return await GenerateHttpResponseWraper<TResponse>(await _HttpClient.PostAsync(_BaseUrl + url, GenerateStringContentFromObject(data)));

        }

        public async Task<HttpResponseWraper<TResponse?>> Put<T, TResponse>(string url, T data)
        {
            return await GenerateHttpResponseWraper<TResponse>(await _HttpClient.PutAsync(_BaseUrl + url, GenerateStringContentFromObject(data)));
        }
    }
}
