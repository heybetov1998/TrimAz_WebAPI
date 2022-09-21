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

    public async Task<Barber> Get(string id)
    {
        var data = await _barberDAL.GetAsync(n => n.Id == id, includes: "UserBarbers");

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public async Task<List<Barber>> GetAll()
    {
        var data = await _barberDAL.GetAllAsync(take: 10, includes: "UserBarbers");

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public Task Create(Barber entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Barber entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}
