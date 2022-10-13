using Business.Services;
using DAL.Abstracts;
using DAL.Context;
using Entity.Entities;
using Entity.Entities.Pivots;
using Exceptions.EntityExceptions;
using Exceptions.FileExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories;

public class ProductRepository : IProductService
{
    private readonly IProductDAL _productDAL;
    private readonly AppDbContext _context;
    private readonly IImageService _imageService;

    public ProductRepository(IProductDAL productDAL, AppDbContext context, IImageService imageService)
    {
        _productDAL = productDAL;
        _context = context;
        _imageService = imageService;
    }

    public async Task<Product> GetAsync(int id)
    {
        var data = await _context.Products
            .Where(n => !n.IsDeleted && n.Id == id)
            .Include(n => n.ProductImages).ThenInclude(n => n.Image)
            .Include(n => n.User).ThenInclude(n => n.UserImages).ThenInclude(n => n.Image)
            .FirstOrDefaultAsync();

        if (data is null) throw new EntityCouldNotFoundException();

        return data;
    }

    public async Task<List<Product>> GetAllAsync(int take)
    {
        var data = await _context.Products
            .Where(n => !n.IsDeleted)
            .Take(take)
            .OrderByDescending(n => n.CreatedDate)
            .Include(n => n.ProductImages).ThenInclude(n => n.Image)
            .Include(n => n.User).ThenInclude(n => n.UserImages).ThenInclude(n => n.Image)
            .ToListAsync();

        if (data is null) throw new EntityCouldNotFoundException();

        return data;
    }
    public async Task CreateAsync(Product entity)
    {
        await _productDAL.CreateAsync(entity);
    }

    public async Task UpdateAsync(int id, Product entity)
    {
        await _productDAL.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        Product product = await GetAsync(id);
        await _productDAL.DeleteAsync(product);
    }

    public async Task<string> UploadAsync(Product product, IFormFile file, bool isMain)
    {
        Image image = await CreateImageAsync(file);

        await _imageService.CreateAsync(image);

        ProductImage productImage = new()
        {
            ProductId = product.Id,
            Product = product,
            ImageId = image.Id,
            Image = image,
            IsMain = isMain
        };

        product.ProductImages.Add(productImage);

        await _productDAL.UpdateAsync(product);

        return "Image added successfully";
    }

    public async Task<string> UploadAsync(Product product, ICollection<IFormFile> files, bool isUpdate)
    {
        string resultMessage = "";
        bool attachMain;
        if (isUpdate)
            attachMain = false;
        else
            attachMain = true;

        if (files.Count > 0)
        {
            foreach (var file in files)
            {
                bool isMain = false;
                if (attachMain is true)
                {
                    isMain = true;
                    attachMain = false;
                }
                await UploadAsync(product, file, isMain: isMain);
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
