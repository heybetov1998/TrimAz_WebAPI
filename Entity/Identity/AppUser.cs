using Entity.Base;
using Entity.Entities;
using Entity.Entities.Pivots;
using Microsoft.AspNetCore.Identity;

namespace Entity.Identity;

public class AppUser : IdentityUser, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Token { get; set; }
    public string? WorkStartTime { get; set; }
    public string? WorkEndTime { get; set; }
    public double? StarRating { get; set; }
    public string RoleName { get; set; }
    public ICollection<Review> Reviews { get; set; }


    public ICollection<Blog> Blogs { get; set; }
    public ICollection<Video> Videos { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
    public ICollection<Product> Products { get; set; }

    //Pivots
    public ICollection<UserImage> UserImages { get; set; }
    public ICollection<UserService> UserServices { get; set; }
    public ICollection<UserTime> UserTimes { get; set; }
    public ICollection<UserBarbershop> UserBarbershops { get; set; }

    public AppUser()
    {
        Reviews = new HashSet<Review>();
        Blogs = new HashSet<Blog>();
        Videos = new HashSet<Video>();
        Feedbacks = new HashSet<Feedback>();
        UserImages = new HashSet<UserImage>();
        UserServices = new HashSet<UserService>();
        UserTimes = new HashSet<UserTime>();
        Products = new HashSet<Product>();
        UserBarbershops = new HashSet<UserBarbershop>();
        Token = default!;
        FirstName = default!;
        LastName = default!;
        RoleName = default!;
    }

}
