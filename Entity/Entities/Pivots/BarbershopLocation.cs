using Entity.Base;

namespace Entity.Entities.Pivots;

public class BarbershopLocation : IEntity
{
    public BarbershopLocation()
    {
        Barbershop = new();
        Location = new();
    }

    public int Id { get; set; }
    public int BarbershopId { get; set; }
    public int LocationId { get; set; }
    public Barbershop Barbershop { get; set; }
    public Location Location { get; set; }
}
