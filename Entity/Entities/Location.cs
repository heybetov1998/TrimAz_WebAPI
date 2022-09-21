using Entity.Base;

namespace Entity.Entities;

public class Location : BaseEntity, IEntity
{
    public string? CoordinateX { get; set; }
    public string? CoordinateY { get; set; }
    public int BarbershopId { get; set; }
    public Barbershop? Barbershop { get; set; }
}
