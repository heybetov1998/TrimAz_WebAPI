using Entity.Base;

namespace Business.Base;

public interface IBaseService<TEntity, TProp>
    where TEntity : class, IEntity, new()
{
    Task<TEntity> Get(TProp id);
    Task<List<TEntity>> GetAll();
    Task Create(TEntity entity);
    Task Update(int id, TEntity entity);
    Task Delete(int id);
}
