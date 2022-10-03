using Entity.Identity;

namespace Business.Auth;

public interface IJwtUtils
{
    public Task<string> GenerateJwtTokenAsync(AppUser user);
    public string? ValidateJwtToken(string token);
    public Task<RefreshToken> GenerateRefreshTokenAsync(string ipAddress);
}
