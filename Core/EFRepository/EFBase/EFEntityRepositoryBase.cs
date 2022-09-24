using Entity.Base;
using Exceptions.EntityExceptions;
using Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.EFRepository.EFBase;

public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext
{
    private readonly TContext _context;

    public EFEntityRepositoryBase(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression = null, int skip = 0, params string[] includes)
    {
        var query = expression is null ?
            _context.Set<TEntity>().AsNoTracking() :
            _context.Set<TEntity>().Where(expression).AsNoTracking();

        query = query.Skip((int)skip);

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var data = await query.FirstOrDefaultAsync();

        if (data is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return data;
    }

    public async Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? expression = null,
        Expression<Func<TEntity, IOrderedEnumerable<TEntity>>>? orderExpression = null,
        int skip = 0,
        int? take = int.MaxValue,
        params string[] includes)
    {
        var query = expression is null ?
            _context.Set<TEntity>().AsNoTracking() :
            orderExpression is null ?
                _context.Set<TEntity>().Where(expression).AsNoTracking() :
                _context.Set<TEntity>().Where(expression).OrderBy(orderExpression).AsNoTracking();

        query.Skip(skip);
        if (take != null) query.Take((int)take);

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var data = await query.ToListAsync();

        return data;
    }

    public async Task CreateAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}
