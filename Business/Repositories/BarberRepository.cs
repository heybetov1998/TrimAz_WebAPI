using Business.Services;
using DAL.Abstracts;
using DAL.Context;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories;

public class BarberRepository : IBarberService
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;


    public BarberRepository(AppDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<AppUser> GetAsync(string id)
    {
        var data = await _context.Users.Where(n => n.Id == id)
            .Include(n => n.UserImages).ThenInclude(n => n.Image)
            .Include(n => n.Videos)
            .Include(n => n.UserServices).ThenInclude(n => n.Service)
            .Include(n => n.UserServices).ThenInclude(n => n.ServiceDetail)
            .FirstOrDefaultAsync();

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public async Task<List<AppUser>> GetAllAsync(int take = int.MaxValue)
    {
        var datas = await _context.Users.Where(n => n.RoleName == "Barber")
            .Include(n => n.UserImages).ThenInclude(n => n.Image)
            .Take(take)
            .ToListAsync();

        if (datas is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return datas;
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
