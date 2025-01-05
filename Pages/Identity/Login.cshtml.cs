using community.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace community.Pages.Identity
{
    [AllowAnonymous]
    public sealed class LoginModel : PageModel
    {
        private readonly UserService _userService;
        public LoginModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGetAsync(string returnUrl = null)
        {
            string provider = "Google";
            // Request a redirect to the external login provider.
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Page("./Login",
                    pageHandler: "Callback",
                    values: new { returnUrl }),
            };
            return new ChallengeResult(provider, authenticationProperties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = CleanReturnUrl(returnUrl);
            var LoggedUser = this.User.Identities.FirstOrDefault();
            var needsFill = false;
            (LoggedUser, needsFill) = AsignCustomClaims(LoggedUser);

            if (LoggedUser.IsAuthenticated)
            {
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(LoggedUser),
                authProperties);
            }

            if (needsFill)
                return LocalRedirect("/users/fill");
            return LocalRedirect(returnUrl);
        }
        
        private (ClaimsIdentity user, bool needsFill) AsignCustomClaims(ClaimsIdentity User)
        {
            try
            {
                var nameIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                Console.WriteLine($"AsignCustomClaims - nameIdClaim: {nameIdClaim}");
                var dbUser = _userService.GetByNameIdentifier(nameIdClaim.Value);

                if (!string.IsNullOrEmpty(dbUser.Role))
                    (User! as ClaimsIdentity).AddClaims(
                        new[] { new Claim(ClaimTypes.Role, dbUser.Role) });

                return (User, dbUser.NicknameIsNameIdentifier());
            }
            catch(Exception e)
            {
                Console.WriteLine($"[ERRO] - AsignCustomClaims - exception: {e}");
            }
            return (User, false);
        }

        private string CleanReturnUrl(string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    returnUrl = returnUrl[0] == '/' ? returnUrl : $"/{returnUrl}";
                    returnUrl = Url.Content($"~{returnUrl}");
                    return returnUrl;
                }
                
                return Url.Content("~/");
            }
            catch(Exception e)
            {
                Console.WriteLine($"[ERRO] - CleanReturnUrl - {e}");
                return Url.Content("~/");
            }
        }
    }
}
