using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Entity.Entities.Pivots;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Http;

namespace Business.Repositories
{
    public class BarbershopRepository : IBarbershopService
    {
        private readonly IBarbershopDAL _barbershopDAL;
        private readonly IImageService _imageService;

        public BarbershopRepository(IBarbershopDAL barbershopDAL, IImageService imageService)
        {
            _barbershopDAL = barbershopDAL;
            _imageService = imageService;
        }

        public async Task<Barbershop> GetAsync(int id)
        {
            var data = await _barbershopDAL.GetAsync(
                expression: n => n.Id == id && !n.IsDeleted,
                includes: new string[] {
                    "BarbershopImages.Image",
                    "UserBarbershops.User.UserImages.Image",
                    "UserBarbershops.User.UserServices.Service",
                    "UserBarbershops.User.UserServices.ServiceDetail"
                });

            if (data is null)
            {
                throw new EntityCouldNotFoundException();
            }

            return data;
        }

        public async Task<List<Barbershop>> GetAllAsync(int take)
        {
            var data = await _barbershopDAL.GetAllAsync(
                n => !n.IsDeleted,
                take: take,
                includes: new string[] {
                    "BarbershopImages.Image",
                    "UserBarbershops.User.UserServices.ServiceDetail"
                });

            if (data is null)
            {
                throw new EntityCouldNotFoundException();
            }

            return data;
        }

        public async Task CreateAsync(Barbershop entity)
        {
            await _barbershopDAL.CreateAsync(entity);
        }

        public async Task UpdateAsync(int id, Barbershop entity)
        {
            await _barbershopDAL.UpdateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadAsync(Barbershop barbershop, IFormFile file, bool isMain)
        {
            Image image = await CreateImageAsync(file);

            await _imageService.CreateAsync(image);

            BarbershopImage barbershopImage = new()
            {
                BarbershopId = barbershop.Id,
                Barbershop = barbershop,
                ImageId = image.Id,
                Image = image,
                IsMain = isMain
            };

            barbershop.BarbershopImages.Add(barbershopImage);

            await _barbershopDAL.UpdateAsync(barbershop);

            return "Image added successfully";
        }

        public async Task<string> UploadAsync(Barbershop barbershop, ICollection<IFormFile> files,bool isUpdate)
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
                    await UploadAsync(barbershop, file, isMain: isMain);
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
}
