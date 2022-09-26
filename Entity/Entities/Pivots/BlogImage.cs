using Entity.Base;

namespace Entity.Entities.Pivots;

public class BlogImage : IEntity
{
    public BlogImage()
    {
        Blog = new();
        Image = new();
    }

    public int Id { get; set; }
    public bool IsMain { get; set; }
    public int BlogId { get; set; }
    public int ImageId { get; set; }
    public Blog Blog { get; set; }
    public Image Image { get; set; }
}
