using Entity.DTO.Image;
using Entity.DTO.User;

namespace Entity.DTO.Product;

public class ProductGetDTO
{
    public ProductGetDTO()
    {
        Seller = new();
        Image = new();
    }

    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public ImageGetDTO Image { get; set; }
    public UserGetDTO Seller { get; set; }
}
