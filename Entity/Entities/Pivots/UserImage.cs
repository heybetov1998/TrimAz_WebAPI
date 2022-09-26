using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots;

public class UserImage : IEntity
{
    public UserImage()
    {
        User = new AppUser();
        Image = new();
    }

    public int Id { get; set; }
    public bool IsAvatar { get; set; }
    public string UserId { get; set; } = default!;
    public int ImageId { get; set; }
    public AppUser User { get; set; }
    public Image Image { get; set; }
}
