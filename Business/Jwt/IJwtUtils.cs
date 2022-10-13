using Entity.Identity;

namespace Business.Jwt;

public interface IJwtUtils
{
    public Task<string> GenerateTokenAsync(AppUser user);
    public string? ValidateToken(string token);
}
