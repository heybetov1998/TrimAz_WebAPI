using Microsoft.AspNetCore.Http;

namespace Entity.DTO.Product;

public class ProductUpdateDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public double Price { get; set; }
    public ICollection<IFormFile> Images { get; set; }

    public ProductUpdateDTO()
    {
        Title = default!;
        Content = default!;
        Images = new HashSet<IFormFile>();
    }
}
