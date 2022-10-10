using Entity.Identity;

namespace Entity.Entities;

public class Video
{
    public Video()
    {
        User = new();
    }

    public int Id { get; set; }
    public string YoutubeLink { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public AppUser User{ get; set; }
}
