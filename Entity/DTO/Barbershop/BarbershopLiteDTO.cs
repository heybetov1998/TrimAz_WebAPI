namespace Entity.DTO.Barbershop;

public class BarbershopLiteDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public BarbershopLiteDTO()
    {
        Name = default!;
    }
}
