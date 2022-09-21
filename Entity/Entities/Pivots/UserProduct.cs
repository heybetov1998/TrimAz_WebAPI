using Entity.Base;
using Entity.Identity;

namespace Entity.Entities;

// User-Product Pivot
public class UserProduct : BaseEntity, IEntity
{
    public string? Message { get; set; }
    public double StarRating { get; set; }
    public string? UserId { get; set; }
    public int ProductId { get; set; }
    public AppUser? User { get; set; }
    public Product? Product { get; set; }
}
