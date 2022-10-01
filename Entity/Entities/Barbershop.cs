using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Barbershop : BaseEntity, IEntity
{
    public Barbershop()
    {
        Users = new HashSet<AppUser>();
        BarbershopImages = new HashSet<BarbershopImage>();
        BarbershopLocations = new HashSet<BarbershopLocation>();
    }

    public string Name { get; set; } = default!;

    public ICollection<AppUser> Users { get; set; }

    //Pivot
    public ICollection<BarbershopImage> BarbershopImages { get; set; }
    public ICollection<BarbershopLocation> BarbershopLocations { get; set; }
}
