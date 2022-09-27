using Entity.DTO.Image;
using Entity.DTO.Review;
using Entity.DTO.Service;
using Entity.DTO.Video;
using Entity.Entities.Pivots;

namespace Entity.DTO.Barber;

public class BarberDetailGetDTO
{
    public BarberDetailGetDTO()
    {
        Images = new HashSet<ImageGetDTO>();
        Services = new HashSet<ServiceTimeGetDTO>();
        Videos = new HashSet<VideoGetDTO>();
        Reviews = new HashSet<ReviewGetDTO>();
    }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Avatar { get; set; } = default!;
    public double StarRating { get; set; }
    public ICollection<ImageGetDTO> Images { get; set; }
    public ICollection<ServiceTimeGetDTO> Services { get; set; }
    public ICollection<VideoGetDTO> Videos { get; set; }
    public ICollection<ReviewGetDTO> Reviews { get; set; }
}
