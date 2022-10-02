namespace Entity.DTO.Barbershop;

public class BarbershopPostDTO
{
    public BarbershopPostDTO()
    {
        Name = default!;
    }

    public string Name { get; set; }
    //public List<> MyProperty { get; set; }
    public double Latitude { get; set; }
    public double Longtitude { get; set; }
    //public List<string> ImageNames{ get; set; }
}
