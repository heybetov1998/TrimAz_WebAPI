using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class UserService : IEntity
{
    public UserService()
    {
        User = new();
        Service = new();
        ServiceDetail = new();
    }

    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int ServiceId { get; set; }
    public int ServiceDetailId { get; set; }
    public AppUser User { get; set; }
    public Service Service { get; set; }
    public ServiceDetail ServiceDetail { get; set; }
}
