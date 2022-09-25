using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Exceptions.EntityExceptions;

namespace Business.Repositories;

public class ProductRepository : IProductService
{
    private readonly IProductDAL _productDAL;

    public ProductRepository(IProductDAL productDAL)
    {
        _productDAL = productDAL;
    }

    public async Task<Product> GetAsync(int id)
    {
        var data = await _productDAL.GetAsync(n => n.Id == id && !n.IsDeleted, includes: new string[] { "ProductImages.Image" });

        if (data is null) throw new EntityCouldNotFoundException();

        return data;
    }

    public async Task<List<Product>> GetAllAsync(int take)
    {
        var data = await _productDAL.GetAllAsync(n => !n.IsDeleted, includes: new string[] { "ProductImages.Image", "Seller.SellerImages.Image" });

        if (data is null) throw new EntityCouldNotFoundException();

        return data;
    }
    public Task CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
