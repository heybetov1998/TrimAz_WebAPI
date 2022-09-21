using Entity.Base;
using Entity.Identity;

namespace Entity.Entities;

public class Feedback : BaseEntity, IEntity
{
    public string? Message { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
}
