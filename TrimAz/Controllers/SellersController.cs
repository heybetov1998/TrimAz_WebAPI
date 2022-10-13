using Business.Services;
using Entity.DTO.Seller;
using Entity.DTO.User;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellersController : ControllerBase
{
    private readonly ISellerService _sellerService;
    private readonly UserManager<AppUser> _userManager;

    public SellersController(ISellerService sellerService, UserManager<AppUser> userManager)
    {
        _sellerService = sellerService;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user is null)
        {
            return NotFound("User not found");
        }

        SellerUpdateDTO sellerUpdateDTO = new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber
        };

        return Ok(sellerUpdateDTO);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int? take)
    {
        take ??= int.MaxValue;

        try
        {
            var datas = await _sellerService.GetAllAsync(take: (int)take);

            List<UserDashDTO> sellers = new();

            foreach (var data in datas)
            {
                UserDashDTO sellerGetDTO = new()
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                };

                sellerGetDTO.Avatar = "profile-picture.png";
                foreach (var userImage in data.UserImages)
                {
                    if (userImage.IsAvatar)
                    {
                        sellerGetDTO.Avatar = userImage.Image.Name;
                    }
                }

                sellers.Add(sellerGetDTO);
            }

            return Ok(sellers);
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
    public async Task<IActionResult> UpdateAsync(string id, [FromForm] SellerUpdateDTO sellerUpdateDTO)
    {
        AppUser seller = await _userManager.FindByIdAsync(sellerUpdateDTO.Id);

        if (seller == null)
        {
            return BadRequest(new { statusCode = 404, message = "User not found" });
        }

        seller.FirstName = sellerUpdateDTO.FirstName;
        seller.LastName = sellerUpdateDTO.LastName;
        seller.PhoneNumber = sellerUpdateDTO.PhoneNumber;

        if (sellerUpdateDTO.AvatarImage is not null)
            await _sellerService.UploadAsync(seller, sellerUpdateDTO.AvatarImage, true);

        await _userManager.UpdateAsync(seller);

        return Ok(new { statusCode = 200, message = "Seller updated successfully" });
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
