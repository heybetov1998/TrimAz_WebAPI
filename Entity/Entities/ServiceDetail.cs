using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities;

public class ServiceDetail : BaseEntity, IEntity
{
    public double Price { get; set; }
    public string? Time { get; set; }

    public List<BarberService>? BarberServices { get; set; }
}
