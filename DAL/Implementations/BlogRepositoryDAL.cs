using Core.EFRepository.EFBase;
using DAL.Abstracts;
using DAL.Context;
using Entity.Entities;

namespace DAL.Implementations;

public class BlogRepositoryDAL : EFEntityRepositoryBase<Blog, AppDbContext>, IBlogDAL
{
    public BlogRepositoryDAL(AppDbContext context) : base(context) { }
}
