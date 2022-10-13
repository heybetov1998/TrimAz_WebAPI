using Business.Base;
using Entity.Identity;
using Microsoft.AspNetCore.Http;

namespace Business.Services;

public interface IBarberService : IBaseService<AppUser, string>
{
    public Task<string> UploadAsync(AppUser user, IFormFile file, bool isAvatar);
    public Task<string> UploadAsync(AppUser user, ICollection<IFormFile> files);
}
