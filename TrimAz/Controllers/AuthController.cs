using Business.Auth;
using Entity.DTO.Identity;
using Entity.Identity;
using Exceptions.AuthExceptions;
using Exceptions.DataExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;
using static TrimAz.Commons.Helpers.Enums;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IEmailSender _emailSender;

    public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _emailSender = emailSender;
    }

    [HttpPost("register")]
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

    [HttpPost("registerOwner")]
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
