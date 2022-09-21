using AutoMapper;
using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Exceptions.EntityExceptions;

namespace Business.Repositories;

public class ProductRepository : IProductService
{
    private readonly IProductDAL _productDAL;

    public ProductRepository(IProductDAL productDAL, IMapper mapper)
    {
        _productDAL = productDAL;
    }

    public async Task<Product> Get(int id)
    {
        var data = await _productDAL.GetAsync(n => n.Id == id && !n.IsDeleted, includes: "ProductImages.Image");

        if (data is null) throw new EntityCouldNotFoundException();

        return data;
    }

    public async Task<List<Product>> GetAll()
    {
        var data = await _productDAL.GetAllAsync(n => !n.IsDeleted, includes: "ProductImages.Image");

        if (data is null) throw new EntityCouldNotFoundException();

        return data;
    }
    public Task Create(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Product entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}
