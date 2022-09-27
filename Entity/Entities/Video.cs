using Entity.Identity;

namespace Entity.Entities;

public class Video
{
    public Video()
    {
        Barber = new();
    }

    public int Id { get; set; }
    public string YoutubeLink { get; set; } = default!;
    public string BarberId { get; set; } = default!;
    public Barber Barber { get; set; }
}
