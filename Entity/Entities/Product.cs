using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Product : BaseEntity, IEntity
{
    public Product()
    {
        ProductImages = new HashSet<ProductImage>();
        CartProducts = new HashSet<CartProduct>();
        UserProducts = new HashSet<UserProduct>();
        Seller = new();
        Location = new();
    }

    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public double Price { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }

    public string SellerId { get; set; } = null!;
    public Seller Seller { get; set; }

    public ICollection<ProductImage> ProductImages { get; set; }
    public ICollection<CartProduct> CartProducts { get; set; }
    public ICollection<UserProduct> UserProducts { get; set; }
}
