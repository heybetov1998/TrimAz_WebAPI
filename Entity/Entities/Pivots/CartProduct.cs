using Entity.Base;

namespace Entity.Entities.Pivots;

public class CartProduct : IEntity
{
    public CartProduct()
    {
        Cart = new();
        Product = new();
    }

    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public Cart Cart { get; set; }
    public Product Product { get; set; }
}
