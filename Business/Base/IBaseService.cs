using Entity.Base;

namespace Business.Base;

public interface IBaseService<TEntity, TProp>
    where TEntity : class, IEntity, new()
{
    Task<TEntity> GetAsync(TProp id);
    Task<List<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(int id, TEntity entity);
    Task DeleteAsync(int id);
}
