using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities;

public class Service : BaseEntity, IEntity
{
    public Service()
    {
        BarberServices = new HashSet<BarberService>();
    }

    public string Name { get; set; } = null!;

    public ICollection<BarberService> BarberServices { get; set; }
}
