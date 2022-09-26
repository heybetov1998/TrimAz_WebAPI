using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities;

public class ServiceDetail : BaseEntity, IEntity
{
    public ServiceDetail()
    {
        BarberServices = new HashSet<BarberService>();
    }

    public double Price { get; set; }
    public string Time { get; set; } = default!;

    public ICollection<BarberService> BarberServices { get; set; }
}
