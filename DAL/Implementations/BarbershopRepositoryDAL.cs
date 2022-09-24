using Core.EFRepository.EFBase;
using DAL.Abstracts;
using DAL.Context;
using Entity.Entities;

namespace DAL.Implementations;

public class BarbershopRepositoryDAL : EFEntityRepositoryBase<Barbershop, AppDbContext>, IBarbershopDAL
{
    public BarbershopRepositoryDAL(AppDbContext context) : base(context) { }
}
