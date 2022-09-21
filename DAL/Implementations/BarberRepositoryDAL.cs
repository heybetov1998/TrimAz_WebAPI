using Core.EFRepository.EFBase;
using DAL.Abstracts;
using DAL.Context;
using Entity.Identity;

namespace DAL.Implementations;

public class BarberRepositoryDAL : EFEntityRepositoryBase<Barber, AppDbContext>, IBarberDAL
{
    public BarberRepositoryDAL(AppDbContext context) : base(context) { }
}
