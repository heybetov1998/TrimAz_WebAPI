using Core.EFRepository.EFBase;
using DAL.Abstracts;
using DAL.Context;
using Entity.Entities;

namespace DAL.Implementations
{
    public class ReviewRepositoryDAL : EFEntityRepositoryBase<Review, AppDbContext>, IReviewDAL
    {
        public ReviewRepositoryDAL(AppDbContext context) : base(context) { }
    }
}
