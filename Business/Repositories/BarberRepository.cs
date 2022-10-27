using Business.Services;
using DAL.Context;
using Entity.Entities;
using Entity.Entities.Pivots;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories;

public class BarberRepository : IBarberService
{
    private readonly AppDbContext _context;
    private readonly IImageService _imageService;
    private readonly UserManager<AppUser> _userManager;


    public BarberRepository(AppDbContext context, UserManager<AppUser> userManager, IImageService imageService)
    {
        _context = context;
        _userManager = userManager;
        _imageService = imageService;
    }

    public async Task<AppUser> GetAsync(string id)
    {
        var data = await _context.Users.Where(n => n.Id == id)
            .Include(n => n.UserImages).ThenInclude(n => n.Image)
            .Include(n => n.Videos)
            .Include(n => n.UserServices).ThenInclude(n => n.Service)
            .Include(n => n.UserServices).ThenInclude(n => n.ServiceDetail)
            .Include(n => n.UserTimes).ThenInclude(n => n.Time)
            .Include(n => n.UserBarbershops).ThenInclude(n => n.Barbershop)
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
            .OrderByDescending(n => n.StarRating)
            .Include(n => n.UserImages).ThenInclude(n => n.Image)
            .Include(n => n.UserServices).ThenInclude(n => n.Service)
            .Include(n => n.UserServices).ThenInclude(n => n.ServiceDetail)
            .Include(n => n.UserTimes).ThenInclude(n => n.Time)
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

    public async Task<string> UploadAsync(AppUser user, IFormFile file, bool isAvatar)
    {
        Image image = await CreateImageAsync(file);

        var altUserData = await GetAsync(user.Id);

        await _imageService.CreateAsync(image);

        if (isAvatar)
        {
            foreach (var ui in altUserData.UserImages)
            {
                if (ui.IsAvatar)
                {
                    await _imageService.DeleteAsync(ui.Image.Id);
                    break;
                }
            }
        }

        UserImage userImage = new()
        {
            UserId = user.Id,
            User = user,
            ImageId = image.Id,
            Image = image,
            IsAvatar = isAvatar
        };

        user.UserImages.Add(userImage);

        await _userManager.UpdateAsync(user);

        return "Image added successfully";
    }

    public async Task<string> UploadAsync(AppUser user, ICollection<IFormFile> files)
    {
        string resultMessage = "";
        if (files.Count > 0)
        {
            foreach (var file in files)
            {
                await UploadAsync(user, file, false);
                resultMessage += "Image added successfully\n";
            }
        }
        return resultMessage;
    }

    private async Task<Image> CreateImageAsync(IFormFile file)
    {
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Images");

        string currentDate = DateTime.UtcNow.AddHours(4).ToString("ddMMyyyy_HHmmss") + Guid.NewGuid().ToString();

        FileInfo fileInfo = new FileInfo(file.FileName);
        string fileName = currentDate + fileInfo.Extension;

        string fileNameWithPath = Path.Combine(pathToSave, fileName);

        using var stream = new FileStream(fileNameWithPath, FileMode.Create);
        await file.CopyToAsync(stream);

        Image image = new();
        image.Name = fileName;

        return image;
    }

    //[HttpPost("deleteImage")]
    //public async Task<IActionResult> DeleteImage(int id, int imageId)
    //{
    //    var path = Path.Combine(Directory.GetCurrentDirectory(), "Images");
    //    var dataDb = await GetAsync(id);
    //    foreach (var blogImage in dataDb.ImageBlogs)
    //    {
    //        if (blogImage.Image.Id == imageId)
    //        {
    //            if (File.Exists(Path.Combine(path, blogImage.Image.Name)))
    //            {
    //                File.Delete(Path.Combine(path, blogImage.Image.Name));
    //            }
    //            await _imageService.Delete(imageId);
    //            break;
    //        }
    //    }

    //    return RedirectToAction(nameof(Update), "Blogs", new { id });
    //}
}
