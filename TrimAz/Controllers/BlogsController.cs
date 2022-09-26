using Business.Services;
using Entity.DTO.Blog;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int? take)
        {
            take ??= int.MaxValue;

            try
            {
                var datas = await _blogService.GetAllAsync(take: (int)take);

                List<BlogGetDTO> blogs = new List<BlogGetDTO>();

                foreach (var data in datas)
                {
                    BlogGetDTO blogGetDTO = new BlogGetDTO();

                    blogGetDTO.Id = data.Id;
                    blogGetDTO.Title = data.Title;
                    blogGetDTO.Content = data.Content;
                    blogGetDTO.CreatedDate = data.CreatedDate;

                    blogGetDTO.Author.Id = data.Barber.Id;
                    blogGetDTO.Author.FirstName = data.Barber.FirstName;
                    blogGetDTO.Author.LastName = data.Barber.LastName;

                    //blogGetDTO.Author.Image
                    blogGetDTO.Author.Image.Name =  "profile-picture.png";
                    foreach (var barberImage in data.Barber.BarberImages)
                    {
                        if (barberImage.IsAvatar)
                        {
                            blogGetDTO.Author.Image.Name = barberImage.Image.Name;
                            break;
                        }
                    }
                    blogGetDTO.Author.Image.Alt = blogGetDTO.Author.Image.Name;

                    //blogGetDTO.Image
                    blogGetDTO.Image.Name = "no-image.png";
                    foreach (var blogImage in data.BlogImages)
                    {
                        if (blogImage.IsMain)
                        {
                            blogGetDTO.Image.Name = blogImage.Image.Name;
                            break;
                        }
                    }
                    blogGetDTO.Image.Alt = blogGetDTO.Image.Name;

                    blogs.Add(blogGetDTO);
                }

                return Ok(blogs);
            }
            catch (EntityCouldNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4001, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4001, ex.Message));
            }
        }
    }
}
