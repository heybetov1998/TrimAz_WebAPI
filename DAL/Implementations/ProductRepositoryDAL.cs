using Core.EFRepository.EFBase;
using DAL.Abstracts;
using DAL.Context;
using Entity.Entities;

namespace DAL.Implementations
{
    public class ProductRepositoryDAL : EFEntityRepositoryBase<Product, AppDbContext>, IProductDAL
    {
        public ProductRepositoryDAL(AppDbContext context) : base(context) { }
    }
}
