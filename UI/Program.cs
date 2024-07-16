using DNSLab.Prividers;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using UI.Components;
using UI.Exceptions;
using UI.Interfaces.Providers;
using UI.Interfaces.Repositories;
using UI.Providers;
using UI.Repositories;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<HttpResponseExceptionHander>();
            builder.Services.AddScoped<IHttpServiceProvider, HttpServiceProvider>();
            builder.Services.AddScoped<HttpClient>();

            //Repository
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();


            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "CustomScheme";
                options.DefaultChallengeScheme = "CustomScheme";
            }).AddScheme<CustomAuthOptions, CustomAuthenticationHandler>("CustomScheme", options => { }); ;

            builder.Services.AddScoped<JWTAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthenticationProvider>(provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());


            // Add MudBlazor services
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopEnd;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddCircuitOptions(option =>
                {
                    //only add details when debugging
                    option.DetailedErrors = builder.Environment.IsDevelopment();
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
