using Business.Auth;
using DAL.Abstracts;
using Entity.DTO.Identity;
using Entity.Identity;
using Exceptions.AuthExceptions;
using Exceptions.DataExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrimAz.Commons;
using static TrimAz.Commons.Helpers.Enums;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserDAL _userDAL;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly IConfiguration _config;

    public AuthController(
        UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
        IEmailSender emailSender, IConfiguration config, IUserDAL userDAL, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _emailSender = emailSender;
        _config = config;
        _userDAL = userDAL;
        _signInManager = signInManager;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
    {
        if (!ModelState.IsValid)
        {
            DataAnnotationNotListenedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4014, ex.Message));
        }

        AppUser appUser = new();

        appUser.FirstName = registerUserDTO.FirstName;
        appUser.LastName = registerUserDTO.LastName;
        appUser.Email = registerUserDTO.Email;
        appUser.UserName = registerUserDTO.UserName;

        var result = await _userManager.CreateAsync(appUser, registerUserDTO.Password);

        if (!result.Succeeded)
        {
            UserCouldNotBeCreatedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4005, ex.Message));
        }

        //await _emailSender.SendEmailAsync(
        //    email: registerUserDTO.Email,
        //    subject: string.Format("Confirm your email address, {0} {1}", registerUserDTO.FirstName, registerUserDTO.LastName),
        //    htmlMessage: "<a href='#'>Confirm email</a>"
        //    );

        var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Member.ToString());

        if (!roleResult.Succeeded)
        {
            RoleCouldNotBeAttachedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4005, ex.Message));
        }

        return Ok(registerUserDTO);
    }

    [HttpPost("RegisterBarber")]
    public async Task<IActionResult> RegisterBarber(RegisterBarberDTO registerBarberDTO)
    {
        return Ok();
    }

    [HttpPost("RegisterOwner")]
    public async Task<IActionResult> RegisterOwner(RegisterUserDTO registerUserDTO)
    {
        if (!ModelState.IsValid)
        {
            DataAnnotationNotListenedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4014, ex.Message));
        }

        AppUser appUser = new();

        appUser.FirstName = registerUserDTO.FirstName;
        appUser.LastName = registerUserDTO.LastName;
        appUser.Email = registerUserDTO.Email;
        appUser.UserName = registerUserDTO.UserName;

        var result = await _userManager.CreateAsync(appUser, registerUserDTO.Password);

        if (!result.Succeeded)
        {
            UserCouldNotBeCreatedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4005, ex.Message));
        }

        //await _emailSender.SendEmailAsync(
        //    email: registerUserDTO.Email,
        //    subject: string.Format("Confirm your email address, {0} {1}", registerUserDTO.FirstName, registerUserDTO.LastName),
        //    htmlMessage: "<a href='#'>Confirm email</a>"
        //    );

        var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Owner.ToString());

        if (!roleResult.Succeeded)
        {
            RoleCouldNotBeAttachedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4005, ex.Message));
        }

        return Ok(registerUserDTO);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
    {
        var user = await AuthenticateAsync(loginUserDTO);

        if (user is not null)
        {
            var token = await GenerateTokenAsync(user);

            return Ok(token);
        }

        return NotFound("User not found");
    }

    //authenticate user
    private async Task<AppUser?> AuthenticateAsync(LoginUserDTO loginUserDTO)
    {
        var currentUser = await _userManager.FindByEmailAsync(loginUserDTO.Email);

        var result = await _signInManager.PasswordSignInAsync(currentUser, loginUserDTO.Password, false, false);

        if (!result.Succeeded)
        {
            InvalidCredentialException ex = new();
            //return StatusCode(StatusCodes.Status403Forbidden, new Response(4003, ex.Message));
            return null;
        }

        return currentUser;
    }

    // token generation
    private async Task<string> GenerateTokenAsync(AppUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>
        {
            new Claim("FirstName",user.FirstName),
            new Claim("LastName",user.LastName)
        };

        foreach (var role in await _userManager.GetRolesAsync(user))
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
             issuer: _config["JWT:Issuer"],
             audience: _config["JWT:Audience"],
             claims: claims,
             expires: DateTime.UtcNow.AddHours(4).AddMinutes(15),
             signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    #region CreateRoles
    //[HttpPost("createRole")]
    //public async Task<IActionResult> CreateRoles(string roleName)
    //{
    //    IdentityRole role = new();

    //    role.Name = roleName;

    //    await _roleManager.CreateAsync(role);

    //    return Ok(role);
    //}
    #endregion
}
