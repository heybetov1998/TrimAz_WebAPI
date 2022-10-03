using Entity.Identity;
using System.Text.Json.Serialization;

namespace Entity.DTO.User;

public class AuthenticateResponse
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string JwtToken { get; set; }

    [JsonIgnore] // refresh token is returned in http only cookie
    public string RefreshToken { get; set; }

    public AuthenticateResponse(AppUser user, string jwtToken, string refreshToken)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        UserName = user.UserName;
        Email = user.Email;
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }
}
