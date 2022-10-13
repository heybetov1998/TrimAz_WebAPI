using Entity.DTO.User;
using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetCurrentUser(string id)
        {
            AppUser currentUser = await _userManager.FindByIdAsync(id);

            if (currentUser is not null)
            {
                UserSettingsDTO userSettingsDTO = new()
                {
                    Id = currentUser.Id,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    UserName = currentUser.UserName,
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

        [HttpPost]
        //[Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateDTO userUpdateDTO)
        {
            AppUser user = await _userManager.FindByEmailAsync(userUpdateDTO.Email);

            if (user == null) return BadRequest(new { statusCode = 403 });

            user.UserName = userUpdateDTO.UserName;
            user.Email = userUpdateDTO.Email;

            await _userManager.UpdateAsync(user);

            return Ok(new { statusCode = 200, message = "User updated successfully" });
        }
    }
}
