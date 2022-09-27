namespace Entity.DTO.Service;

public class ServiceTimeGetDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public double Price { get; set; }
    public string Time { get; set; } = default!;
}
