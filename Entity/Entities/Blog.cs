using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Blog : BaseEntity, IEntity
{
    public Blog()
    {
        BlogImages = new HashSet<BlogImage>();
        User = new();
    }

    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public AppUser User{ get; set; }

    public ICollection<BlogImage> BlogImages { get; set; }
}
