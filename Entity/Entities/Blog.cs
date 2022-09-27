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

    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string BarberId { get; set; } = default!;
    public Barber Barber { get; set; }

    public ICollection<BlogImage> BlogImages { get; set; }
}
