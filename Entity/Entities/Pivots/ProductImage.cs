using Entity.Base;

namespace Entity.Entities.Pivots;

public class ProductImage : IEntity
{
    public ProductImage()
    {
        Product = new();
        Image = new();
    }

    public int Id { get; set; }
    public bool IsMain { get; set; }
    public int ProductId { get; set; }
    public int ImageId { get; set; }
    public Product Product { get; set; }
    public Image Image { get; set; }
}
