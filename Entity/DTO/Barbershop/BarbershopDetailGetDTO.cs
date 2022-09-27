using Entity.DTO.Barber;
using Entity.DTO.Image;
using Entity.DTO.Location;
using Entity.DTO.Review;
using Entity.DTO.Service;

namespace Entity.DTO.Barbershop;

public class BarbershopDetailGetDTO
{
    public BarbershopDetailGetDTO()
    {
        Barbers = new HashSet<BarberGetDTO>();
        Services = new HashSet<ServiceGetDTO>();
        Images = new HashSet<string>();
        Locations = new HashSet<LocationGetDTO>();
        Reviews = new HashSet<ReviewGetDTO>();
    }

    public string Name { get; set; }
    public ICollection<BarberGetDTO> Barbers { get; set; }
    public ICollection<LocationGetDTO> Locations { get; set; }
    public ICollection<ServiceGetDTO> Services { get; set; }
    public ICollection<string> Images { get; set; }
    public ICollection<ReviewGetDTO> Reviews { get; set; }
}
