using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities;

public class Service : BaseEntity, IEntity
{
    public string? Name { get; set; }

    public List<BarberService>? BarberServices { get; set; }
}
