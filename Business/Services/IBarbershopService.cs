using Business.Base;
using Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Services;

public interface IBarbershopService : IBaseService<Barbershop, int>
{
    public Task<string> UploadAsync(Barbershop barbershop, IFormFile file, bool isMain);
    public Task<string> UploadAsync(Barbershop barbershop, ICollection<IFormFile> files, bool isUpdate);
}
