using Business.Services;
using Entity.DTO.Identity;
using Entity.DTO.User;
using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TrimAz.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(LoginUserDTO model)
    {
        var response = await _userService.AuthenticateAsync(model, ipAddress());
        setTokenCookie(response.RefreshToken);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshTokenAsync()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (refreshToken is null)
        {
            return StatusCode(StatusCodes.Status403Forbidden, "Refresh token is null");
        }

        var response = await _userService.RefreshTokenAsync(refreshToken, ipAddress());

        setTokenCookie(response.RefreshToken);

        return Ok(response);
    }

    [HttpPost("revoke-token")]
    public async Task<IActionResult> RevokeTokenAsync(RevokeTokenRequest model)
    {
        // accept refresh token in request body or cookie
        var token = model.Token ?? Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(token))
            return BadRequest(new { message = "Token is required" });

        await _userService.RevokeTokenAsync(token, ipAddress());
        return Ok(new { message = "Token revoked" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var user = await _userService.GetAsync(id);
        return Ok(user);
    }

    [HttpGet("{id}/refresh-tokens")]
    public async Task<IActionResult> GetRefreshTokensAsync(string id)
    {
        var user = await _userService.GetAsync(id);
        return Ok(user.RefreshTokens);
    }

    // helper methods

    private void setTokenCookie(string token)
    {
        // append cookie with refresh token to the http response
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", token, cookieOptions);
    }

    private string ipAddress()
    {
        // get source ip address for the current request
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}
