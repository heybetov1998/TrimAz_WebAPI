using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class UserBarber : BaseEntity, IEntity
{
    public UserBarber()
    {
        User = new();
        Barber = new();
    }

    public string Message { get; set; } = default!;
    public double StarRating { get; set; }
    public string UserId { get; set; } = default!;
    public string BarberId { get; set; } = default!;
    public AppUser User { get; set; }
    public Barber Barber { get; set; }
}
