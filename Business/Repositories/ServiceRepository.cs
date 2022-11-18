using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Exceptions.EntityExceptions;

namespace Business.Repositories;

public class ServiceRepository : IServiceService
{
    private readonly IServiceDAL _serviceDAL;

    public ServiceRepository(IServiceDAL serviceDAL)
    {
        _serviceDAL = serviceDAL;
    }

    public Task<Service> GetAsync(int id)
    {
        var data = _serviceDAL.GetAsync(
            expression: n => !n.IsDeleted && n.Id == id,
            includes: new string[] { "UserServices.ServiceDetail" }
            );

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public Task<List<Service>> GetAllAsync(int take = int.MaxValue)
    {
        var data = _serviceDAL.GetAllAsync(
            expression: n => !n.IsDeleted,
            includes: new string[] { "UserServices.ServiceDetail" },
            take: take);

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public Task CreateAsync(Service entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Service entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
