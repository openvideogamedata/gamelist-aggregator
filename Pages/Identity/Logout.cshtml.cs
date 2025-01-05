using community.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace community.Pages.Identity
{
    public class LogoutModel : PageModel
    {
        public UserService _userService { get; private set; }
        public string ReturnUrl { get; private set; }

        public LogoutModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            try
            {
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO] - Logout error: {ex}");
            }
            return LocalRedirect("/");
        }
    }
}