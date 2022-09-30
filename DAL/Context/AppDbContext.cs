using Entity.Entities;
using Entity.Entities.Pivots;
using Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Barber>? Barbers { get; set; }
    public DbSet<Barbershop>? Barbershops { get; set; }
    public DbSet<Blog>? Blogs { get; set; }
    public DbSet<Cart>? Carts { get; set; }
    public DbSet<Feedback>? Feedbacks { get; set; }
    public DbSet<Image>? Images { get; set; }
    public DbSet<Location>? Locations { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Seller>? Sellers { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<ServiceDetail>? ServiceDetails { get; set; }
    public DbSet<Time>? Times { get; set; }
    public DbSet<Video>? Videos { get; set; }

    //Pivots
    public DbSet<BarberImage>? BarberImages { get; set; }
    public DbSet<BarberService>? BarberServices { get; set; }
    public DbSet<BarbershopImage>? BarbershopImages { get; set; }
    public DbSet<BlogImage>? BlogImages { get; set; }
    public DbSet<CartProduct>? CartProducts { get; set; }
    public DbSet<ProductImage>? ProductImages { get; set; }
    public DbSet<SellerImage>? SellerImages { get; set; }
    public DbSet<UserBarber>? UserBarbers { get; set; }
    public DbSet<UserImage>? UserImages { get; set; }
    public DbSet<UserProduct>? UserProducts { get; set; }
    public DbSet<BarberTime>? BarberTimes { get; set; }
}
