using Business.Base;
using Entity.DTO.Identity;
using Entity.DTO.User;
using Entity.Identity;

namespace Business.Services
{
    public interface IUserService : IBaseService<AppUser, string>
    {
        Task<AuthenticateResponse> AuthenticateAsync(LoginUserDTO model, string ipAddress);
        Task<AuthenticateResponse> RefreshTokenAsync(string token, string ipAddress);
        Task RevokeTokenAsync(string token, string ipAddress);
    }
}
