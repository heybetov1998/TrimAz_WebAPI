using DAL.Abstracts;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Business.Auth;

public class JwtUtils : IJwtUtils
{
    private IUserDAL _userDAL;
    private readonly JWTConfig _jwtConfig;
    private readonly UserManager<AppUser> _userManager;

    public JwtUtils(IOptions<JWTConfig> jwtConfig, UserManager<AppUser> userManager, IUserDAL userDAL)
    {
        _jwtConfig = jwtConfig.Value;
        _userDAL = userDAL;
        _userManager = userManager;
    }
    public async Task<string> GenerateJwtTokenAsync(AppUser user)
    {
        // generate token that is valid for 15 minutes
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtConfig.Key);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var roles = await _userManager.GetRolesAsync(user);

        List<Claim> claims = new List<Claim>
        {
            new Claim("id",user.Id),
            new Claim("firstName",user.FirstName),
            new Claim("lastName",user.LastName),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim("userName",user.UserName)
        };
        claims.AddRange(roles.Select(n => new Claim(ClaimTypes.Role, n)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = credentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public string? ValidateJwtToken(string token)
    {
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtConfig.Key);

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

    public async Task<RefreshToken> GenerateRefreshTokenAsync(string ipAddress)
    {
        var refreshToken = new RefreshToken
        {
            Token = await getUniqueTokenAsync(),
            // token is valid for 7 days
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };

        return refreshToken;

        async Task<string> getUniqueTokenAsync()
        {
            // token is a cryptographically strong random sequence of values
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            // ensure token is unique by checking against db
            var users = await _userDAL.GetAllAsync();

            var tokenIsUnique = !users.Any(u => u.RefreshTokens.Any(t => t.Token == token));

            if (!tokenIsUnique)
                return await getUniqueTokenAsync();

            return token;
        }
    }
}
