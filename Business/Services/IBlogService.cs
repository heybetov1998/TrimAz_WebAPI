using Business.Base;
using Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Services;

public interface IBlogService : IBaseService<Blog, int>
{
    public Task<string> UploadAsync(Blog blog, IFormFile file, bool isMain);
    public Task<string> UploadAsync(Blog blog, ICollection<IFormFile> files);
}
