using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class UserImage : IEntity
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public int ImageId { get; set; }
    public AppUser? User { get; set; }
    public Image? Image { get; set; }
}
