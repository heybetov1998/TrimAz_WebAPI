using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Cart : BaseEntity, IEntity
{
    public Cart()
    {
        User = new AppUser();
        CartProducts = new HashSet<CartProduct>();
    }

    public string UserId { get; set; } = default!;
    public AppUser User { get; set; }

    public ICollection<CartProduct> CartProducts { get; set; }
}
