using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Exceptions.FileExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IImageService _imageService;

        public UploadController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            try
            {
                Image image = await CreateImageAsync(file);

                await _imageService.CreateAsync(image);

                return Ok(new { status = 200, message = "Added successfully" });
            }
            catch (FileUploadFailedException ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, new Response(4017, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status415UnsupportedMediaType, new Response(4015, ex.Message));
            }
        }

        [HttpPost("Multiple")]
        public async Task<IActionResult> UploadAsync(List<IFormFile> files)
        {
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    await UploadAsync(file);
                }

                return Ok(new { status = 200, message = "All files added successfully" });
            }

            return NotFound("No file detected");
        }

        private async Task<Image> CreateImageAsync(IFormFile file)
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            string currentDate = DateTime.UtcNow.AddHours(4).ToString("ddMMyyyy_HHmmss");

            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = currentDate + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(pathToSave, fileName);

            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await file.CopyToAsync(stream);

            Image image = new();
            image.Name = fileName;

            return image;
        }
    }
}
