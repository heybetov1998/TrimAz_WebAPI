using Entity.DTO.Image;
using Entity.DTO.User;

namespace Entity.DTO.Blog;

public class BlogGetDTO
{
    public BlogGetDTO()
    {
        Image = new();
        Author = new();
    }

    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public ImageGetDTO Image { get; set; }
    public UserGetDTO Author { get; set; }
    public DateTime CreatedDate { get; set; }
}
