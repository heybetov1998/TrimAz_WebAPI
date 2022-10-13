using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities;

public class Service : BaseEntity, IEntity
{
    public Service()
    {
        UserServices = new HashSet<UserService>();
    }

    public string Name { get; set; } = default!;

    public ICollection<UserService> UserServices { get; set; }
}
