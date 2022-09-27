using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class BarberImage : IEntity
{
    public BarberImage()
    {
        Barber = new();
        Image = new();
    }

    public int Id { get; set; }
    public bool IsAvatar { get; set; }
    public string BarberId { get; set; } = default!;
    public int ImageId { get; set; }
    public Barber Barber { get; set; }
    public Image Image { get; set; }
}
