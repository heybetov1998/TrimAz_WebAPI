using Business.Services;
using Entity.DTO.Blog;
using Entity.DTO.Image;
using Entity.Entities;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var data = await _blogService.GetAsync(id);

                BlogDetailGetDTO blog = new();

                // Title // Content // CreatedDate
                blog.Title = data.Title;
                blog.Content = data.Content;
                blog.CreatedDate = data.CreatedDate;

                // Author
                blog.Author.Id = data.User.Id;
                blog.Author.FirstName = data.User.FirstName;
                blog.Author.LastName = data.User.LastName;

                //Author Image
                blog.Author.Image.Name = "profile-picture.png";
                foreach (var userImage in data.User.UserImages)
                {
                    if (userImage.IsAvatar)
                    {
                        blog.Author.Image.Name = userImage.Image.Name;
                        break;
                    }
                }
                blog.Author.Image.Alt = blog.Author.Image.Name;

                //Blog Images
                foreach (var blogImage in data.BlogImages)
                {
                    ImageMainGetDTO image = new();

                    image.Name = blogImage.Image.Name;
                    image.IsMain = blogImage.IsMain;

                    blog.Images.Add(image);
                }

                return Ok(blog);
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
                    BlogGetDTO blogGetDTO = new();

                    blogGetDTO.Id = data.Id;
                    blogGetDTO.Title = data.Title;
                    blogGetDTO.Content = data.Content;
                    blogGetDTO.CreatedDate = data.CreatedDate;

                    blogGetDTO.Author.Id = data.User.Id;
                    blogGetDTO.Author.FirstName = data.User.FirstName;
                    blogGetDTO.Author.LastName = data.User.LastName;

                    //blogGetDTO.Author.Image
                    blogGetDTO.Author.Image.Name = "profile-picture.png";
                    foreach (var userImage in data.User.UserImages)
                    {
                        if (userImage.IsAvatar)
                        {
                            blogGetDTO.Author.Image.Name = userImage.Image.Name;
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] BlogCreateDTO blogCreateDTO)
        {
            Blog blog = new()
            {
                Title = blogCreateDTO.Title,
                Content = blogCreateDTO.Content,
                UserId = blogCreateDTO.UserId,
                CreatedDate = DateTime.UtcNow.AddHours(4),
            };

            await _blogService.CreateAsync(blog);

            await _blogService.UploadAsync(blog, blogCreateDTO.Images, isUpdate: false);

            return Ok(blog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] BlogUpdateDTO blogUpdateDTO)
        {
            Blog blog = await _blogService.GetAsync(id);

            blog.Title = blogUpdateDTO.Title;
            blog.Content = blogUpdateDTO.Content;
            blog.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _blogService.UploadAsync(blog, blogUpdateDTO.Images, isUpdate: true);

            await _blogService.UpdateAsync(blog.Id, blog);

            return Ok(blog);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _blogService.DeleteAsync(id);

            return Ok(new { statusCode = 200, message = "Blog deleted successfully" });
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetBySearch(string search)
        {
            try
            {
                var datas = await _blogService.GetAllAsync();
                string[] splits = search.Split(" ");

                List<BlogGetDTO> blogs = new List<BlogGetDTO>();

                foreach (var data in datas)
                {
                    bool isValid = false;

                    foreach (var split in splits)
                    {
                        if (data.Title.ToLower().Contains(split.ToLower()))
                        {
                            isValid = true;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        BlogGetDTO blogGetDTO = new();

                        blogGetDTO.Id = data.Id;
                        blogGetDTO.Title = data.Title;
                        blogGetDTO.Content = data.Content;
                        blogGetDTO.CreatedDate = data.CreatedDate;

                        blogGetDTO.Author.Id = data.User.Id;
                        blogGetDTO.Author.FirstName = data.User.FirstName;
                        blogGetDTO.Author.LastName = data.User.LastName;

                        //blogGetDTO.Author.Image
                        blogGetDTO.Author.Image.Name = "profile-picture.png";
                        foreach (var userImage in data.User.UserImages)
                        {
                            if (userImage.IsAvatar)
                            {
                                blogGetDTO.Author.Image.Name = userImage.Image.Name;
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
