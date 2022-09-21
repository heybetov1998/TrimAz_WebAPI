using Entity.Base;
using Entity.Entities;
using Entity.Entities.Pivots;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entity.Identity;

public class Barber : IdentityUser, IEntity
{
    public Barber()
    {
        BarberImages = new HashSet<BarberImage>();
        UserBarbers = new HashSet<UserBarber>();
        BarberServices = new HashSet<BarberService>();
        Barbershop = new();
    }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int BarbershopId { get; set; }
    public Barbershop Barbershop { get; set; }

    //Pivot
    public ICollection<BarberImage> BarberImages { get; set; }
    public ICollection<UserBarber> UserBarbers { get; set; }
    public ICollection<BarberService> BarberServices { get; set; }
}
