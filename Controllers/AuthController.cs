using System.Security.Claims;
using community.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace community.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpGet("login")]
    public IActionResult Login([FromQuery] string? returnUrl = null)
    {
        var authenticationProperties = new AuthenticationProperties
        {
            RedirectUri = Url.Action(nameof(Callback), values: new { returnUrl })
        };

        return new ChallengeResult("Google", authenticationProperties);
    }

    [AllowAnonymous]
    [HttpGet("callback")]
    public async Task<IActionResult> Callback([FromQuery] string? returnUrl = null, [FromQuery] string? remoteError = null)
    {
        returnUrl = CleanReturnUrl(returnUrl);
        var identity = User.Identities.FirstOrDefault();
        var needsFill = false;

        if (identity != null)
        {
            (identity, needsFill) = AssignCustomClaims(identity);

            if (identity.IsAuthenticated)
            {
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = Request.Host.Value
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    authProperties);
            }
        }

        if (needsFill)
        {
            return LocalRedirect("/users/fill");
        }

        return LocalRedirect(returnUrl);
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout([FromQuery] string? returnUrl = null)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return LocalRedirect(CleanReturnUrl(returnUrl));
    }

    [AllowAnonymous]
    [HttpGet("session")]
    public IActionResult Session()
    {
        var isAuthenticated = User.Identity?.IsAuthenticated ?? false;
        if (!isAuthenticated)
        {
            return Ok(new { isAuthenticated });
        }

        var nameIdentifier = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        return Ok(new
        {
            isAuthenticated,
            nameIdentifier,
            name = User.Identity?.Name,
            roles = User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList()
        });
    }

    private (ClaimsIdentity user, bool needsFill) AssignCustomClaims(ClaimsIdentity user)
    {
        try
        {
            var nameIdClaim = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (nameIdClaim == null || string.IsNullOrWhiteSpace(nameIdClaim.Value))
            {
                return (user, false);
            }

            var dbUser = _userService.GetByNameIdentifier(nameIdClaim.Value);
            if (dbUser != null && !string.IsNullOrEmpty(dbUser.Role))
            {
                user.AddClaims(new[] { new Claim(ClaimTypes.Role, dbUser.Role) });
            }

            return (user, dbUser?.NicknameIsNameIdentifier() ?? false);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[ERRO] - AssignCustomClaims - exception: {e}");
        }

        return (user, false);
    }

    private string CleanReturnUrl(string? returnUrl)
    {
        try
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                var normalized = returnUrl[0] == '/' ? returnUrl : $"/{returnUrl}";
                return Url.Content($"~{normalized}");
            }

            return Url.Content("~/");
        }
        catch (Exception e)
        {
            Console.WriteLine($"[ERRO] - CleanReturnUrl - {e}");
            return Url.Content("~/");
        }
    }
}
