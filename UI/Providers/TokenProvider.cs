using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using UI.Interfaces.Providers;

namespace UI.Providers
{
    public class TokenProvider(ProtectedLocalStorage _LocalStorage) : ITokenProvider
    {
        private readonly string TokenKey = "TOKENKEY";
        public async Task DeleteTokenAsync()
        {
            await _LocalStorage.DeleteAsync(TokenKey);
        }

        public async Task<string> GetRefreshTokenAsync()
        {
            try
            {
                var model = await _LocalStorage.GetAsync<AuthUserDTO>(TokenKey);

                if (model.Success)
                {
                    if (model.Value!.RefreshTokenExpiryTime > DateTime.UtcNow)
                    {
                        return model.Value.RefreshToken;
                    }
                }

            }
            catch { }

            return String.Empty;
        }

        public async Task<string> GetTokenAsync()
        {
            try
            {
                var model = await _LocalStorage.GetAsync<AuthUserDTO>(TokenKey);

                if (model.Success)
                {
                    if (!String.IsNullOrEmpty(model.Value!.Token))
                    {
                        if (model.Value!.TokenExpiryTime > DateTime.UtcNow)
                        {
                            return model.Value.Token;
                        }

                    }
                }
            }
            catch { }

            return String.Empty;
        }

        public async Task SetTokenAsync(AuthUserDTO model)
        {
            await _LocalStorage.SetAsync(TokenKey, model);
        }
    }
}
