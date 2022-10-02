using Business.Auth;
using DAL.Abstracts;
using Entity.DTO.Identity;
using Entity.DTO.User;
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

    #region Member Registration
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(RegisterUserDTO registerUserDTO, string roleName = "Member")
    {
        if (!ModelState.IsValid)
        {
            DataAnnotationNotListenedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4014, ex.Message));
        }

        AppUser appUser = new();

        appUser.FirstName = Capitalize(registerUserDTO.FirstName.Trim());
        appUser.LastName = Capitalize(registerUserDTO.LastName.Trim());
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

        var roleResult = await _userManager.AddToRoleAsync(appUser, roleName);

        if (!roleResult.Succeeded)
        {
            RoleCouldNotBeAttachedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4005, ex.Message));
        }

        return Ok(registerUserDTO);
    }
    #endregion

    #region Barber Registration
    [HttpPost("RegisterBarber")]
    public async Task<IActionResult> RegisterAsync(RegisterBarberDTO registerBarberDTO)
    {
        if (!ModelState.IsValid)
        {
            DataAnnotationNotListenedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4014, ex.Message));
        }

        AppUser appUser = new();

        appUser.FirstName = Capitalize(registerBarberDTO.FirstName.Trim());
        appUser.LastName = Capitalize(registerBarberDTO.LastName.Trim());
        appUser.Email = registerBarberDTO.Email;
        appUser.UserName = registerBarberDTO.UserName;
        appUser.WorkStartTime = registerBarberDTO.WorkStartTime;
        appUser.WorkEndTime = registerBarberDTO.WorkEndTime;

        var result = await _userManager.CreateAsync(appUser, registerBarberDTO.Password);

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

        var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Barber.ToString());

        if (!roleResult.Succeeded)
        {
            RoleCouldNotBeAttachedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4005, ex.Message));
        }

        return Ok(registerBarberDTO);
    }
    #endregion

    #region Owner Registration
    [HttpPost("RegisterOwner")]
    public async Task<IActionResult> RegisterOwnerAsync(RegisterUserDTO registerUserDTO)
    {
        return await RegisterAsync(registerUserDTO, Roles.Owner.ToString());
    }
    #endregion

    #region Seller Registration
    [HttpPost("RegisterSeller")]
    public async Task<IActionResult> RegisterSellerAsync(RegisterUserDTO registerUserDTO)
    {
        return await RegisterAsync(registerUserDTO, Roles.Seller.ToString());
    }
    #endregion

    #region Admin Registration
    //[HttpPost("RegisterAdmin")]
    //public async Task<IActionResult> RegisterAdminAsync(RegisterUserDTO registerUserDTO)
    //{
    //    return await RegisterAsync(registerUserDTO, Roles.Admin.ToString());
    //}
    #endregion

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
    {
        var user = await AuthenticateAsync(loginUserDTO);

        if (user is not null)
        {
            var token = await GenerateTokenAsync(user);

            List<string> roleNames = new();

            var roles = await _userManager.GetRolesAsync(user);

            UserRoleGetDTO userRoleGetDTO = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleNames = roles
            };

            return Ok(new { statusCode = 200, token, user = userRoleGetDTO });
        }

        return NotFound(new { statusCode = 404 });
    }

    //authenticate user
    private async Task<AppUser?> AuthenticateAsync(LoginUserDTO loginUserDTO)
    {
        var currentUser = await _userManager.FindByEmailAsync(loginUserDTO.Email);

        var result = await _signInManager.PasswordSignInAsync(currentUser, loginUserDTO.Password, false, false);

        if (!result.Succeeded)
        {
            return null;
        }

        return currentUser;
    }

    // token generation
    private async Task<string> GenerateTokenAsync(AppUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var roles = await _userManager.GetRolesAsync(user);

        List<Claim> claims = new List<Claim>
        {
            new Claim("FirstName",user.FirstName),
            new Claim("LastName",user.LastName)
        };

        claims.AddRange(roles.Select(n => new Claim(ClaimTypes.Role, n)));

        var token = new JwtSecurityToken(
             issuer: _config["JWT:Issuer"],
             audience: _config["JWT:Audience"],
             claims: claims,
             expires: DateTime.UtcNow.AddHours(4).AddMinutes(15),
             signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    //capitalize string
    private string Capitalize(string value)
    {
        return char.ToUpper(value[0]) + value.Substring(1);
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
