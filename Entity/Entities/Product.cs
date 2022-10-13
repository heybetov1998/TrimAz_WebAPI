using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entities;

public class Product : BaseEntity, IEntity
{
    public Product()
    {
        ProductImages = new HashSet<ProductImage>();
        User = new();
    }

    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public double Price { get; set; }

    public string UserId { get; set; } = default!;
    public AppUser User { get; set; }

    public ICollection<ProductImage> ProductImages { get; set; }
}
