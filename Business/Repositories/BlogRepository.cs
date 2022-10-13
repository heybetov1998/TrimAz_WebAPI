using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Entity.Entities.Pivots;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Http;

namespace Business.Repositories;

public class BlogRepository : IBlogService
{
    private readonly IBlogDAL _blogDAL;
    private readonly IImageService _imageService;

    public BlogRepository(IBlogDAL blogDAL, IImageService imageService)
    {
        _blogDAL = blogDAL;
        _imageService = imageService;
    }

    public async Task<Blog> GetAsync(int id)
    {
        var datas = await _blogDAL.GetAsync(
            expression: n => !n.IsDeleted && n.Id == id,
            includes: new string[] {
                "BlogImages.Image",
                "User.UserImages.Image" }
            );

        if (datas is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return datas;
    }

    public async Task<List<Blog>> GetAllAsync(int take = int.MaxValue)
    {
        var datas = await _blogDAL.GetAllAsync(
            expression: n => !n.IsDeleted,
            take: take,
            includes: new string[] { "BlogImages.Image", "User.UserImages.Image" }
            );

        if (datas is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return datas;
    }

    public async Task CreateAsync(Blog entity)
    {
        await _blogDAL.CreateAsync(entity);
    }

    public async Task UpdateAsync(int id, Blog entity)
    {
        await _blogDAL.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        Blog blog = await GetAsync(id);

        if (blog is null)
        {
            return;
        }

        await _blogDAL.DeleteAsync(blog);
    }

    public async Task<string> UploadAsync(Blog blog, IFormFile file, bool isMain)
    {
        Image image = await CreateImageAsync(file);

        await _imageService.CreateAsync(image);

        BlogImage blogImage = new()
        {
            BlogId = blog.Id,
            Blog = blog,
            ImageId = image.Id,
            Image = image,
            IsMain = isMain
        };

        blog.BlogImages.Add(blogImage);

        await _blogDAL.UpdateAsync(blog);

        return "Image added successfully";
    }

    public async Task<string> UploadAsync(Blog blog, ICollection<IFormFile> files, bool isUpdate)
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
                await UploadAsync(blog, file, isMain: isMain);
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
