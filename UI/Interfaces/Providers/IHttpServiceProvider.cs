using UI.DTOs.Providers;

namespace UI.Interfaces.Providers
{
    public interface IHttpServiceProvider
    {
        Task<HttpResponseWraper<TResponse?>> Get<TResponse>(string url);
        Task<HttpResponseWraper<TResponse?>> Post<T, TResponse>(string url, T data);
        Task<HttpResponseWraper<TResponse?>> Put<T, TResponse>(string url, T data);
        Task<HttpResponseWraper<TResponse?>> Delete<TResponse>(string url);
    }
}
