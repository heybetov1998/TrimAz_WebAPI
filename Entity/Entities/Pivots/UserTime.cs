using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class UserTime : IEntity
{
    public UserTime()
    {
        User = new();
        Time = new();
    }

    public int Id { get; set; }
    public bool IsWorkHour { get; set; }
    public bool IsReserved { get; set; }
    public string UserId { get; set; } = default!;
    public int TimeId { get; set; }
    public AppUser User { get; set; }
    public Time Time { get; set; }
}
