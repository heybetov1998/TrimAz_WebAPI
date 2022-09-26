using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Blog : BaseEntity, IEntity
{
    public Blog()
    {
        BlogImages = new HashSet<BlogImage>();
        Barber = new();
    }

    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string BarberId { get; set; } = null!;
    public Barber Barber { get; set; }

    public ICollection<BlogImage> BlogImages { get; set; }
}
