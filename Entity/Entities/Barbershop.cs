using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Barbershop : BaseEntity, IEntity
{
    public Barbershop()
    {
        BarbershopImages = new HashSet<BarbershopImage>();
        UserBarbershops = new HashSet<UserBarbershop>();
    }

    public string Name { get; set; } = default!;
    public string Latitude { get; set; }
    public string Longtitude { get; set; }


    //Pivot
    public ICollection<BarbershopImage> BarbershopImages { get; set; }
    public ICollection<UserBarbershop> UserBarbershops { get; set; }

}
