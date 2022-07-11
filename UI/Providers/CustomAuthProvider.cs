using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using ClasesAhorcado;

namespace UI.Providers
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return new AuthenticationState(claimsPrincipal);
        }

        public void SetAuthInfo(Usuario userProfile)
        {
            var identity = new ClaimsIdentity(new[]{
            new Claim(ClaimTypes.NameIdentifier, userProfile.Username)
            }, "AuthCookie");

            claimsPrincipal = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void ClearAuthInfo()
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
