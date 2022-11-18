namespace Entity.DTO.Service;

public class ServiceUpdateDTO
{
    public string BarberId { get; set; }

    public string Services { get; set; }
    public ServiceUpdateDTO()
    {
        BarberId = default!;
        Services = default!;
    }
}
