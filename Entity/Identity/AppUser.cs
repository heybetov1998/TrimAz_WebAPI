using Entity.Base;
using Entity.Entities;
using Entity.Entities.Pivots;
using Microsoft.AspNetCore.Identity;

namespace Entity.Identity;

public class AppUser : IdentityUser, IEntity
{
    public AppUser()
    {
        Feedbacks = new HashSet<Feedback>();
        UserProducts = new HashSet<UserProduct>();
        UserImages = new HashSet<UserImage>();
        UserBarbers = new HashSet<UserBarber>();
    }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public ICollection<Feedback> Feedbacks { get; set; }

    //Pivots
    public ICollection<UserProduct> UserProducts { get; set; }
    public ICollection<UserImage> UserImages { get; set; }
    public ICollection<UserBarber> UserBarbers { get; set; }
}
