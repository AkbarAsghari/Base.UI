namespace UI.Interfaces.Providers
{
    public interface IAuthenticationProvider
    {
        Task Login(AuthUserDTO model);
        Task Logout();
    }
}
