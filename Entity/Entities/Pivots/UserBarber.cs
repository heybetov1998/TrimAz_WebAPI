using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class UserBarber : BaseEntity, IEntity
{
    public string? Message { get; set; }
    public double StarRating { get; set; }
    public string? UserId { get; set; }
    public string? BarberId { get; set; }
    public AppUser? User { get; set; }
    public Barber? Barber { get; set; }
}
