using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTO.Barbershop;

public class BarbershopPostDTO
{
    public string OwnerId { get; set; }
    [Required]
    public string Name { get; set; }

    public ICollection<IFormFile> Images { get; set; }


    [Required]
    public decimal Latitude { get; set; }

    [Required]
    public decimal Longtitude { get; set; }

    public BarbershopPostDTO()
    {
        Name = default!;
        OwnerId = default!;
        Images = new HashSet<IFormFile>();
    }
}
