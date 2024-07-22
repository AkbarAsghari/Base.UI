namespace UI.AppSettings;

public sealed class GlobalSettings
{
    public const string ApplicationName = "My Application";
    public const bool RightToLeft = true;
    public const bool DarkMode = true;
    public const string APIBaseAddress = "https://localhost:7087/";
}

public sealed class AuthorizeRoles
{
    public const string Admin = "Admin";
    public const string Writer = "Writer";
    public const string User = "User";
}