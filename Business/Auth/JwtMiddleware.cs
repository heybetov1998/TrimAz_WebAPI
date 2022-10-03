using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Business.Auth;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JWTConfig _jwtConfig;

    public JwtMiddleware(RequestDelegate next, IOptions<JWTConfig> jwtConfig)
    {
        _next = next;
        _jwtConfig = jwtConfig.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token == null)
            return;
        
        var userId = jwtUtils.ValidateJwtToken(token);
        if (userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetAsync(userId);
        }

        await _next(context);
    }
}
