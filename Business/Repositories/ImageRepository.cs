using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Exceptions.EntityExceptions;

namespace Business.Repositories;

public class ImageRepository : IImageService
{
    private readonly IImageDAL _imageDAL;

    public ImageRepository(IImageDAL imageDAL)
    {
        _imageDAL = imageDAL;
    }

    public async Task<Image> GetAsync(int id)
    {
        var data = await _imageDAL.GetAsync(n => n.Id == id);

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public async Task<List<Image>> GetAllAsync(int take)
    {
        var data = await _imageDAL.GetAllAsync();

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public async Task CreateAsync(Image entity)
    {
        await _imageDAL.CreateAsync(entity);
    }

    public Task UpdateAsync(int id, Image entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
