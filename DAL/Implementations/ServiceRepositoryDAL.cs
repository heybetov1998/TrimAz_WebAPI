using Core.EFRepository.EFBase;
using DAL.Abstracts;
using DAL.Context;
using Entity.Entities;

namespace DAL.Implementations
{
    public class ServiceRepositoryDAL : EFEntityRepositoryBase<Service, AppDbContext>, IServiceDAL
    {
        public ServiceRepositoryDAL(AppDbContext context) : base(context) { }
    }
}
