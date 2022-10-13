using Microsoft.AspNetCore.Http;

namespace Entity.DTO.Blog
{
    public class BlogUpdateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<IFormFile> Images { get; set; }

        public BlogUpdateDTO()
        {
            Title = default!;
            Content = default!;
            Images = new HashSet<IFormFile>();
        }
    }
}