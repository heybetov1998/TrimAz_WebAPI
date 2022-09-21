using Entity.Base;

namespace Entity.Entities.Pivots;

public class BarbershopImage : IEntity
{
    public int Id { get; set; }
    public int BarbershopId { get; set; }
    public int ImageId { get; set; }
    public Barbershop? Barbershop { get; set; }
    public Image? Image { get; set; }
}
