using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class BarberImage : IEntity
{
    public int Id { get; set; }
    public string? BarberId { get; set; }
    public int ImageId { get; set; }
    public Barber? Barber { get; set; }
    public Image? Image { get; set; }
}
