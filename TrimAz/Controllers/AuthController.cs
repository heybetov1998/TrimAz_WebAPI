using Entity.DTO.Identity;
using Entity.Identity;
using Exceptions.AuthExceptions;
using Microsoft.AspNetCore.Http;
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

    public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
    {
        AppUser appUser = new();

        appUser.FirstName = registerUserDTO.FirstName;
        appUser.LastName = registerUserDTO.LastName;
        appUser.Email = registerUserDTO.Email;
        appUser.UserName = registerUserDTO.UserName;

        var result = await _userManager.CreateAsync(appUser, registerUserDTO.Password);

        if (!result.Succeeded)
        {
            throw new UserCouldNotBeCreatedException();
        }

        //await _context.SaveChangesAsync();

        var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Member.ToString());

        if (!roleResult.Succeeded)
        {
            throw new RoleCouldNotBeAttachedException();
        }

        return Ok(appUser);
    }

    //[HttpPost("createRole")]
    //public async Task<IActionResult> CreateRoles(string roleName)
    //{
    //    IdentityRole role = new();

    //    role.Name = roleName;
        
    //    await _roleManager.CreateAsync(role);
        
    //    return Ok(role);
    //}
}
