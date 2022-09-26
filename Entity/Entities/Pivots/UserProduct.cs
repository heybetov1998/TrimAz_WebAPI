using Entity.Base;
using Entity.Identity;

namespace Entity.Entities;

// User-Product Pivot
public class UserProduct : BaseEntity, IEntity
{
    public UserProduct()
    {
        User = new AppUser();
        Product = new();
    }

    public string Message { get; set; } = default!;
    public double StarRating { get; set; }
    public string UserId { get; set; } = default!;
    public int ProductId { get; set; }
    public AppUser User { get; set; }
    public Product Product { get; set; }
}
