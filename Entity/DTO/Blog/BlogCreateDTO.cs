using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTO.Blog;

public class BlogCreateDTO
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    public string UserId { get; set; }
    
    public ICollection<IFormFile> Images { get; set; }

    public BlogCreateDTO()
    {
        Title = default!;
        Content = default!;
        UserId = default!;
        Images= new HashSet<IFormFile>();
    }
}
