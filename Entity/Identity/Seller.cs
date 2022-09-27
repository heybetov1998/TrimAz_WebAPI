using Entity.Base;
using Entity.Entities;
using Entity.Entities.Pivots;
using Microsoft.AspNetCore.Identity;

namespace Entity.Identity;

public class Seller : IdentityUser, IEntity
{
    public Seller()
    {
        Products = new HashSet<Product>();
        SellerImages = new HashSet<SellerImage>();
    }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public ICollection<Product> Products { get; set; }

    //Pivots
    public ICollection<SellerImage> SellerImages { get; set; }
}
