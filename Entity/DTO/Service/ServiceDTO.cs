namespace Entity.DTO.Service;

public class ServiceDTO
{
    public string Name { get; set; }
    public double Price { get; set; }

    public ServiceDTO()
    {
        Name = default!;
    }
}
