using Entity.DTO.Barbershop;

namespace Entity.DTO.Barber;

public class BarberGetDTO
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string ImageName { get; set; } = null!;
    public double StarRating { get; set; }
    public BarbershopLiteDTO Barbershop { get; set; }

    public BarberGetDTO()
    {
        Barbershop = new();
    }
}
