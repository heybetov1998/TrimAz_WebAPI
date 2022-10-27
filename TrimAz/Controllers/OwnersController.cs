using DAL.Context;
using Entity.DTO.Owner;
using Entity.DTO.User;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrimAz.Commons;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public OwnersController(AppDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(string id)
    {
        var owner = await _userManager.FindByIdAsync(id);

        if (owner is null)
        {
            return NotFound("User not found");
        }

        OwnerGetDTO ownerDto = new()
        {

        };

        return Ok(ownerDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var datas = await _context.Users.Where(n => n.RoleName == "Owner").ToListAsync();

            List<UserDashDTO> owners = new();

            foreach (var data in datas)
            {
                UserDashDTO ownerGetDTO = new()
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                };

                ownerGetDTO.Avatar = "profile-picture.png";
                foreach (var userImage in data.UserImages)
                {
                    if (userImage.IsAvatar)
                    {
                        ownerGetDTO.Avatar = userImage.Image.Name;
                    }
                }

                owners.Add(ownerGetDTO);
            }

            return Ok(owners);
        }
        catch (EntityCouldNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response(4001, ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response(4001, ex.Message));
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user is null)
        {
            return NotFound("User not found");
        }

        await _userManager.DeleteAsync(user);

        return Ok(new { statusCode = 200, message = "User deleted successfully" });
    }
}
