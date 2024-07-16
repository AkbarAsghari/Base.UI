namespace UI.Interfaces.Providers
{
    public interface IAuthenticationProvider
    {
        Task Login(string token);
        Task Logout();
    }
}
