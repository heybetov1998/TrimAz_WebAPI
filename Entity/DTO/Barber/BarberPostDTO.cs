using Entity.DTO.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTO.Barber
{
    public class BarberPostDTO : RegisterUserDTO
    {
        [Required]
        public string WorkStartTime { get; set; } = default!;

        [Required]
        public string WorkEndTime { get; set; } = default!;

        [Required]
        public int BarbershopId { get; set; }
    }
}
