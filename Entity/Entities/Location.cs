using Entity.Base;

namespace Entity.Entities;

public class Location : BaseEntity, IEntity
{
    public Location()
    {
        Products = new HashSet<Product>();
    }

    public double Latitude { get; set; }
    public double Longtitude { get; set; }
    public ICollection<Product> Products { get; set; }
}
