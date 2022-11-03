using Business.Services;
using Entity.DTO.User;
using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;

        public UsersController(UserManager<AppUser> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetCurrentUser(string id)
        {
            AppUser currentUser = await _userService.GetAsync(id);

            if (currentUser is not null)
            {
                UserSettingsDTO userSettingsDTO = new()
                {
                    Id = currentUser.Id,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    UserName = currentUser.UserName,
                    PhoneNumber = currentUser.PhoneNumber,
                    Email = currentUser.Email
                };

                //Avatar
                userSettingsDTO.Avatar = "profile-picture.png";
                foreach (var userImage in currentUser.UserImages)
                {
                    if (userImage.IsAvatar)
                    {
                        userSettingsDTO.Avatar = userImage.Image.Name;
                        break;
                    }
                }

                return Ok(userSettingsDTO);
            }

            return NotFound(new { statusCode = 404, message = "User not found" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromForm] UserUpdateDTO userUpdateDTO)
        {
            AppUser user = await _userManager.FindByIdAsync(userUpdateDTO.Id);

            if (user == null) return BadRequest(new { statusCode = 403 });

            user.FirstName = userUpdateDTO.FirstName;
            user.LastName = userUpdateDTO.LastName;

            if (userUpdateDTO.PhoneNumber != "null")
            {
                user.PhoneNumber = userUpdateDTO.PhoneNumber;
            }

            if (userUpdateDTO.AvatarImage is not null)
                await _userService.UploadAsync(user, userUpdateDTO.AvatarImage, true);

            await _userManager.UpdateAsync(user);

            return await GetCurrentUser(user.Id);
        }
    }
}
