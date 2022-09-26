using Entity.Base;

namespace Entity.Entities;

public class Location : BaseEntity, IEntity
{
    public Location()
    {
        Products = new HashSet<Product>();
    }

    public string CoordinateX { get; set; } = default!;
    public string CoordinateY { get; set; } = default!;
    public ICollection<Product> Products { get; set; }
}
