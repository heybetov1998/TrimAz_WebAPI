using Business.Services;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Identity;

namespace Business.Repositories;

public class SellerRepository : ISellerService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SellerRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<List<AppUser>> GetAllAsync(int take = int.MaxValue)
    {
        List<AppUser> sellers = (List<AppUser>)await _userManager.GetUsersInRoleAsync("Seller");

        if (sellers is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return sellers;
    }

    public Task<AppUser> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(AppUser entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, AppUser entity)
    {
        throw new NotImplementedException();
    }
}
