using System.Security.Claims;
using community.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace community.Middlewares;

public sealed class UserInfoMiddleware
{
    private readonly UserService _userService;
    private readonly RequestDelegate _next;
    public UserInfoMiddleware(UserService userService, RequestDelegate next)
    {
        _userService = userService;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            if (_userService.IsLogged())
            {
                if (_userService.UserIsBanned(_userService.GetLoggedUserNameIdentifier()))
                {
                    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    context.Response.Redirect("/banned");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"[ERRO] - UserInfoMiddleware {e.Message}\n{e}");
        }

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}
