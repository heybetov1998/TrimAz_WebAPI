using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities;

public class Product : BaseEntity, IEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public double Price { get; set; }

    public List<ProductImage>? ProductImages { get; set; }
    public List<CartProduct>? CartProducts { get; set; }
    public List<UserProduct>? UserProducts { get; set; }
}
