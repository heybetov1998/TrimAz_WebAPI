using Core.EFRepository.EFBase;
using DAL.Abstracts;
using DAL.Context;
using Entity.Entities;

namespace DAL.Implementations;

public class ImageRepositoryDAL : EFEntityRepositoryBase<Image, AppDbContext>, IImageDAL
{
    public ImageRepositoryDAL(AppDbContext context) : base(context) { }
}
