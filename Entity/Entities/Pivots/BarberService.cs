using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class BarberService : IEntity
{
    public BarberService()
    {
        Barber = new();
        Service = new();
        ServiceDetail = new();
    }

    public int Id { get; set; }
    public string BarberId { get; set; } = default!;
    public int ServiceId { get; set; }
    public int ServiceDetailId { get; set; }
    public Barber Barber { get; set; }
    public Service Service { get; set; }
    public ServiceDetail ServiceDetail { get; set; }
}
