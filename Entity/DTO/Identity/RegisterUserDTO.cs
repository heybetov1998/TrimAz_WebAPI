using System.ComponentModel.DataAnnotations;

namespace Entity.DTO.Identity
{
    public class RegisterUserDTO
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required, MinLength(6), MaxLength(50)]
        public string UserName { get; set; } = null!;

        [Required, DataType(DataType.Password), MaxLength(50)]
        public string Password { get; set; } = null!;

        [Required, DataType(DataType.Password), MaxLength(50), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
