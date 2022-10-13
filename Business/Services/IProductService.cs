
using Business.Base;
using Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Services;

public interface IProductService : IBaseService<Product, int>
{
    public Task<string> UploadAsync(Product product, IFormFile file,bool isMain);
    public Task<string> UploadAsync(Product product, ICollection<IFormFile> files, bool isUpdate);
}
