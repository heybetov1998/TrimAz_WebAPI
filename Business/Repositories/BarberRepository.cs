using Business.Services;
using DAL.Abstracts;
using Entity.Identity;
using Exceptions.EntityExceptions;

namespace Business.Repositories;

public class BarberRepository : IBarberService
{
    private readonly IBarberDAL _barberDAL;
    public BarberRepository(IBarberDAL barberDAL)
    {
        _barberDAL = barberDAL;
    }

    public async Task<Barber> GetAsync(string id)
    {
        var data = await _barberDAL.GetAsync(n => n.Id == id, includes: "UserBarbers");

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public async Task<List<Barber>> GetAllAsync(int take = int.MaxValue)
    {
        var data = await _barberDAL.GetAllAsync(
            take: take,
            includes: new string[] { "UserBarbers", "BarberImages.Image" });

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public Task CreateAsync(Barber entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Barber entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
