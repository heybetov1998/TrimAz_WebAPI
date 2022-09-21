using Entity.Base;
using System.Linq.Expressions;

namespace Core.EFRepository.EFBase;

public interface IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
{
    Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>>? expression = null, 
        int? skip = 0,
        params string[] includes);
    Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? expression = null,
        Expression<Func<TEntity, double>>? orderExpression = null,
        int? skip = 0,
        int? take = int.MaxValue, 
        params string[] includes);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
