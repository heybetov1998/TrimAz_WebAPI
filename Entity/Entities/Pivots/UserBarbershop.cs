using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class UserBarbershop : IEntity
{
    public UserBarbershop()
    {
        UserId = default!;
        User = new AppUser();
        Barbershop = new();
    }

    public int Id { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public int BarbershopId { get; set; }
    public Barbershop Barbershop { get; set; }
}
