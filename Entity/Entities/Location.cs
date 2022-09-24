using Entity.Base;

namespace Entity.Entities;

public class Location : BaseEntity, IEntity
{
    public Location()
    {
        Products = new HashSet<Product>();
    }

    public string CoordinateX { get; set; } = null!;
    public string CoordinateY { get; set; } = null!;
    public ICollection<Product> Products { get; set; }
}
