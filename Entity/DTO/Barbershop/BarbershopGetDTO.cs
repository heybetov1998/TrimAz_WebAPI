using Entity.DTO.Image;

namespace Entity.DTO.Barbershop;

public class BarbershopGetDTO
{
    public BarbershopGetDTO()
    {
        Image = new();
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public string AfterPrice { get; set; } = null!;
    public ImageGetDTO Image { get; set; }
}
