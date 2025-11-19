using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.JSInterop;
using SeamLessGoWeb.Models;

namespace SeamLessGoWeb.Services.Auth
{
    public class CustomAuthStateProvider: AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;
        private const string SessionKey = "AUTH_SESSION";
        public CustomAuthStateProvider(IJSRuntime js)
        {
            _js = js;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", SessionKey);

            if (string.IsNullOrEmpty(json))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var session = JsonSerializer.Deserialize<UserSession>(json);

            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, session.UserName),
            new Claim(ClaimTypes.Role, session.UserRoleID.ToString())
        }, "custom");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        public async Task SaveSession(UserSession session)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", SessionKey,
                JsonSerializer.Serialize(session));

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task Logout()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", SessionKey);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
