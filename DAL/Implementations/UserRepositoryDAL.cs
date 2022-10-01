using Core.EFRepository.EFBase;
using DAL.Abstracts;
using DAL.Context;
using Entity.Identity;

namespace DAL.Implementations
{
    public class UserRepositoryDAL : EFEntityRepositoryBase<AppUser, AppDbContext>, IUserDAL
    {
        public UserRepositoryDAL(AppDbContext context) : base(context) { }
    }
}
