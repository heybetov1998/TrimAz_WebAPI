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

public class SellerRepository : ISellerService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IImageService _imageService;
    private readonly AppDbContext _context;

    public SellerRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
        IImageService imageService, AppDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _imageService = imageService;
        _context = context;
    }
    public async Task<List<AppUser>> GetAllAsync(int take = int.MaxValue)
    {
        var sellers = await _context.Users.Where(n => n.RoleName == "Seller")
           .Include(n => n.UserImages).ThenInclude(n => n.Image)
           .Take(take)
           .ToListAsync();

        if (sellers is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return sellers;
    }

    public async Task<AppUser> GetAsync(string id)
    {
        var data = await _context.Users.Where(n => n.Id == id)
           .Include(n => n.UserImages).ThenInclude(n => n.Image)
           .FirstOrDefaultAsync();

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

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, AppUser entity)
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
