using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Jwt;

public class JwtUtils : IJwtUtils
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AppSettings _appSettings;

    public JwtUtils(IOptions<AppSettings> appSettings, UserManager<AppUser> userManager)
    {
        _appSettings = appSettings.Value;
        _userManager = userManager;
    }

    public async Task<string> GenerateTokenAsync(AppUser user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_appSettings.Key);

        var roles = await _userManager.GetRolesAsync(user);

        List<Claim> claims = new List<Claim>
        {
            new Claim("id",user.Id),
            new Claim("firstName",user.FirstName),
            new Claim("lastName",user.LastName),
            new Claim("email",user.Email),
            new Claim("userName",user.UserName),
            new Claim("token",user.Token)
        };

        claims.AddRange(roles.Select(n => new Claim(ClaimTypes.Role, n)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string? ValidateToken(string token)
    {
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_appSettings.Key);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return null;
        }
    }
}
