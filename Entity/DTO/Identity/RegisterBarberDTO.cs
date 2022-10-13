namespace Entity.DTO.Identity;

public class RegisterBarberDTO : RegisterUserDTO
{
    public string WorkStartTime { get; set; } = default!;
    public string WorkEndTime { get; set; } = default!;
}
