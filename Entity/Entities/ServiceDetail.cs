using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities;

public class ServiceDetail : BaseEntity, IEntity
{
    public ServiceDetail()
    {
        UserServices = new HashSet<UserService>();
    }

    public double Price { get; set; }
    //public string Time { get; set; } = default!;

    public ICollection<UserService> UserServices { get; set; }
}
