using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class BarberTime : IEntity
{
    public BarberTime()
    {
        Barber = new();
        Time = new();
    }

    public int Id { get; set; }
    public bool IsWorkHour { get; set; }
    public bool IsReserved { get; set; }
    public string BarberId { get; set; } = default!;
    public int TimeId { get; set; }
    public Barber Barber { get; set; }
    public Time Time { get; set; }
}
