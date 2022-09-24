using AutoMapper;
using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Identity;

namespace Business.Repositories;

public class ProductRepository : IProductService
{
    private readonly IProductDAL _productDAL;
    private readonly UserManager<Seller> _userManager;

    public ProductRepository(IProductDAL productDAL, UserManager<Seller> userManager)
    {
        _productDAL = productDAL;
        _userManager = userManager;
    }

    public async Task<Product> GetAsync(int id)
    {
        var data = await _productDAL.GetAsync(n => n.Id == id && !n.IsDeleted, includes: new string[] { "ProductImages.Image" });

        if (data is null) throw new EntityCouldNotFoundException();

        return data;
    }

    public async Task<List<Product>> GetAllAsync()
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
