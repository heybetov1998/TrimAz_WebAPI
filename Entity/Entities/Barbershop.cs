using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Barbershop : BaseEntity, IEntity
{
    public Barbershop()
    {
        Barbers = new HashSet<Barber>();
        BarbershopImages = new HashSet<BarbershopImage>();
        BarbershopLocations = new HashSet<BarbershopLocation>();
    }

    public string Name { get; set; } = null!;

    public ICollection<Barber> Barbers { get; set; }

    //Pivot
    public ICollection<BarbershopImage> BarbershopImages { get; set; }
    public ICollection<BarbershopLocation> BarbershopLocations { get; set; }
}
