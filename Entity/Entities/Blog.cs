using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Blog : BaseEntity, IEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public List<BlogImage>? BlogImages { get; set; }
}
