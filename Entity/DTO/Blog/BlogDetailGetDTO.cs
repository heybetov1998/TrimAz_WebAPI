using Entity.DTO.Image;
using Entity.DTO.User;

namespace Entity.DTO.Blog;

public class BlogDetailGetDTO
{
    public BlogDetailGetDTO()
    {
        Images = new HashSet<ImageMainGetDTO>();
        Author = new();
    }

    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public ICollection<ImageMainGetDTO> Images { get; set; }
    public UserGetDTO Author { get; set; }
}
