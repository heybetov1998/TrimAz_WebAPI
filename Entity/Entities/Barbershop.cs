using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Barbershop : BaseEntity, IEntity
{
    public string? Name { get; set; }

    public List<Location>? Locations { get; set; }
    public List<Barber>? Barbers { get; set; }

    //Pivot
    public List<BarbershopImage>? BarbershopImages { get; set; }
}
