using Entity.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Jwt;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly UserManager<AppUser> _userManager;

    public JwtMiddleware(RequestDelegate next, UserManager<AppUser> userManager)
    {
        _next = next;
        _userManager = userManager;
    }

    public async Task InvokeAsync(HttpContext context, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token == null)
        {
            return;
        }

        var userId = jwtUtils.ValidateToken(token);

        if (userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = await _userManager.FindByIdAsync(userId);
        }

        await _next(context);
    }
}
