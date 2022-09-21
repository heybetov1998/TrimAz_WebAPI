using Entity.Base;

namespace Entity.Entities.Pivots;

public class ProductImage : IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ImageId { get; set; }
    public Product? Product { get; set; }
    public Image? Image { get; set; }
}
