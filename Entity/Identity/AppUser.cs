using Entity.Entities;
using Entity.Entities.Pivots;
using Microsoft.AspNetCore.Identity;

namespace Entity.Identity;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public List<Blog>? Blogs { get; set; }
    public List<Feedback>? Feedbacks { get; set; }

    //Pivots
    public List<UserProduct>? UserProducts { get; set; }
    public List<UserImage>? UserImages { get; set; }
    public List<UserBarber>? UserBarbers { get; set; }
}
