using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTO.Product;

public class ProductCreateDTO
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public double Price { get; set; }
    public ICollection<IFormFile> Images { get; set; }

    [Required]
    public string UserId { get; set; }

    public ProductCreateDTO()
    {
        Title = default!;
        Content = default!;
        UserId = default!;
        Images=new HashSet<IFormFile>();
    }
}
