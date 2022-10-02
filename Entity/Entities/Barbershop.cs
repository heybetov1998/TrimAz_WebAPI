﻿using Entity.Base;
using Entity.Entities.Pivots;
using Entity.Identity;

namespace Entity.Entities;

public class Barbershop : BaseEntity, IEntity
{
    public Barbershop()
    {
        BarbershopImages = new HashSet<BarbershopImage>();
        BarbershopLocations = new HashSet<BarbershopLocation>();
        UserBarbershops = new HashSet<UserBarbershop>();
    }

    public string Name { get; set; } = default!;


    //Pivot
    public ICollection<BarbershopImage> BarbershopImages { get; set; }
    public ICollection<BarbershopLocation> BarbershopLocations { get; set; }
    public ICollection<UserBarbershop> UserBarbershops { get; set; }

}
