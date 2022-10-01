using System.ComponentModel.DataAnnotations;

namespace Entity.DTO.Identity;

public class LoginUserDTO
{
    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
