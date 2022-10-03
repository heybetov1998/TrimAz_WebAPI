using Business.Auth;
using Business.Services;
using DAL.Abstracts;
using Entity.DTO.Identity;
using Entity.DTO.User;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using BCrypt.Net;
using Exceptions.AppExceptions;

namespace Business.Repositories;

public class UserRepository : IUserService
{
    private readonly IUserDAL _userDAL;
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtUtils _jwtUtils;
    private readonly JWTConfig _jwtConfig;

    public UserRepository(UserManager<AppUser> userManager, IUserDAL userDAL, IJwtUtils jwtUtils, IOptions<JWTConfig> jwtConfig)
    {
        _userDAL = userDAL;
        _jwtUtils = jwtUtils;
        _jwtConfig = jwtConfig.Value;
        _userManager = userManager;
    }

    public async Task<AppUser> GetAsync(string id)
    {
        var data = await _userDAL.GetAsync(
            expression: n => n.Id == id);

        if (data is null)
        {
            throw new KeyNotFoundException("User not found");
        }

        return data;
    }

    public Task<List<AppUser>> GetAllAsync(int take = int.MaxValue)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(AppUser entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, AppUser entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthenticateResponse> AuthenticateAsync(LoginUserDTO model, string ipAddress)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        // validate
        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Username or password is incorrect");

        // authentication successful so generate jwt and refresh tokens
        var jwtToken = await _jwtUtils.GenerateJwtTokenAsync(user);
        var refreshToken = await _jwtUtils.GenerateRefreshTokenAsync(ipAddress);
        user.RefreshTokens.Add(refreshToken);

        // remove old refresh tokens from user
        removeOldRefreshTokens(user);

        // save changes to db
        await _userManager.UpdateAsync(user);

        return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
    }

    public async Task<AuthenticateResponse> RefreshTokenAsync(string token, string ipAddress)
    {
        var user = await getUserByRefreshTokenAsync(token);
        var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        if (refreshToken.IsRevoked)
        {
            // revoke all descendant tokens in case this token has been compromised
            revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");

            await _userManager.UpdateAsync(user);
        }

        if (!refreshToken.IsActive)
            throw new AppException("Invalid token");

        // replace old refresh token with a new one (rotate token)
        var newRefreshToken = await rotateRefreshTokenAsync(refreshToken, ipAddress);
        user.RefreshTokens.Add(newRefreshToken);

        // remove old refresh tokens from user
        removeOldRefreshTokens(user);

        // save changes to db
        await _userManager.UpdateAsync(user);

        // generate new jwt
        var jwtToken = await _jwtUtils.GenerateJwtTokenAsync(user);

        return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
    }

    public async Task RevokeTokenAsync(string token, string ipAddress)
    {
        var user = await getUserByRefreshTokenAsync(token);
        var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        if (!refreshToken.IsActive)
            throw new AppException("Invalid token");

        // revoke token and save
        revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");

        await _userManager.UpdateAsync(user);
    }






    // helper methods

    private async Task<AppUser> getUserByRefreshTokenAsync(string token)
    {
        var users = await _userDAL.GetAllAsync();
        var user = users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

        if (user == null)
            throw new AppException("Invalid token");

        return user;
    }

    private async Task<RefreshToken> rotateRefreshTokenAsync(RefreshToken refreshToken, string ipAddress)
    {
        var newRefreshToken = await _jwtUtils.GenerateRefreshTokenAsync(ipAddress);
        revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    private void removeOldRefreshTokens(AppUser user)
    {
        // remove old inactive refresh tokens from user based on TTL in app settings
        user.RefreshTokens.RemoveAll(x =>
            !x.IsActive &&
            x.Created.AddDays(_jwtConfig.RefreshTokenTTL) <= DateTime.UtcNow);
    }

    private void revokeDescendantRefreshTokens(RefreshToken refreshToken, AppUser user, string ipAddress, string reason)
    {
        // recursively traverse the refresh token chain and ensure all descendants are revoked
        if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
        {
            var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);

            if (childToken == null)
            {
                throw new NullReferenceException();
            }

            if (childToken.IsActive)
                revokeRefreshToken(childToken, ipAddress, reason);
            else
                revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
        }
    }

    private void revokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ipAddress;

        if (reason is not null)
            token.ReasonRevoked = reason;
        if (replacedByToken is not null)
            token.ReplacedByToken = replacedByToken;
    }
}
