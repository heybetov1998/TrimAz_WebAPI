using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Exceptions.EntityExceptions;

namespace Business.Repositories;

public class BlogRepository : IBlogService
{
    private readonly IBlogDAL _blogDAL;

    public BlogRepository(IBlogDAL blogDAL)
    {
        _blogDAL = blogDAL;
    }

    public async Task<Blog> GetAsync(int id)
    {
        var datas = await _blogDAL.GetAsync(
            expression: n => !n.IsDeleted && n.Id == id,
            includes: new string[] { 
                "BlogImages.Image", 
                "Barber.BarberImages.Image" }
            );

        if (datas is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return datas;
    }

    public async Task<List<Blog>> GetAllAsync(int take = int.MaxValue)
    {
        var datas = await _blogDAL.GetAllAsync(
            expression: n => !n.IsDeleted,
            take: take,
            includes: new string[] { "BlogImages.Image", "Barber.BarberImages.Image" }
            );

        if (datas is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return datas;
    }

    public Task CreateAsync(Blog entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Blog entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
