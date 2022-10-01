using Business.Services;
using DAL.Abstracts;
using Entity.Identity;
using Exceptions.EntityExceptions;

namespace Business.Repositories;

public class BarberRepository : IBarberService
{
    private readonly IUserDAL _userDAL;

    public BarberRepository(IUserDAL userDAL)
    {
        _userDAL = userDAL;
    }

    public async Task<AppUser> GetAsync(string id)
    {
        var data = await _userDAL.GetAsync(
            expression: n => n.Id == id,
            includes: new string[] {
                "UserBarbers.User",
                "BarberImages.Image",
                "BarberServices.Service",
                "BarberServices.ServiceDetail",
                "Videos"
            });

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public async Task<List<AppUser>> GetAllAsync(int take = int.MaxValue)
    {
        var data = await _userDAL.GetAllAsync(
            take: take,
            includes: new string[] { "UserBarbers", "BarberImages.Image" });

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
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
}
