using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //For Admin Only
        [HttpGet("Admins"), Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            if (currentUser is not null)
            {
                return Ok($"Hi, you are an {currentUser.FirstName}");
            }

            return NotFound("User not found");
        }


        private AppUser? GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity is null)
            {
                return null;
            }

            var userClaims = identity.Claims;
            return new AppUser
            {
                FirstName = userClaims.FirstOrDefault(n => n.Type == "FirstName")?.Value!,
                LastName = userClaims.FirstOrDefault(n => n.Type == "LastName")?.Value!,
            };
        }
    }
}
