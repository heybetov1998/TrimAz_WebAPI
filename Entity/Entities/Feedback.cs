using Entity.Base;
using Entity.Identity;

namespace Entity.Entities;

public class Feedback : BaseEntity, IEntity
{
    public Feedback()
    {
        User = new AppUser();
    }

    public string Message { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public AppUser User { get; set; }
}
