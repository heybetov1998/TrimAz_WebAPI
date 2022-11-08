using Business.Services;
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
    private readonly IOwnerService _ownerService;

    public OwnersController(AppDbContext context, UserManager<AppUser> userManager, IOwnerService ownerService)
    {
        _context = context;
        _userManager = userManager;
        _ownerService = ownerService;
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
            Id = owner.Id,
            FirstName = owner.FirstName,
            LastName = owner.LastName,
        };

        return Ok(ownerDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var datas = await _ownerService.GetAllAsync();

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
                        break;
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

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] OwnerUpdateDTO ownerUpdateDTO)
    {
        AppUser owner = await _userManager.FindByIdAsync(ownerUpdateDTO.Id);

        if (owner == null) return BadRequest(new { statusCode = 404, message = "User not found" });

        owner.FirstName = ownerUpdateDTO.FirstName;
        owner.LastName = ownerUpdateDTO.LastName;

        if (ownerUpdateDTO.AvatarImage is not null)
            await _ownerService.UploadAsync(owner, ownerUpdateDTO.AvatarImage, true);

        await _userManager.UpdateAsync(owner);

        string avatarImage = "";
        foreach (var ui in owner.UserImages)
        {
            if (ui.IsAvatar)
            {
                avatarImage = ui.Image.Name;
                break;
            }
        }

        return Ok(new { statusCode = 200, avatarImage, message = "Owner updated successfully" });
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
