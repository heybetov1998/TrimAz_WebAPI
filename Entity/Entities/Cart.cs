using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Cart : BaseEntity, IEntity
{
    public string? UserId { get; set; }
    public AppUser? User { get; set; }

    public List<CartProduct>? CartProducts { get; set; }
}
