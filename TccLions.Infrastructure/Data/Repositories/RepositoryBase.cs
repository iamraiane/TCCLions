using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Core;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : Entity<TKey>
{
    private readonly ApplicationDataContext _context;
    protected DbSet<TEntity> _entity;
    public RepositoryBase(ApplicationDataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entity = _context.Set<TEntity>();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Create(TEntity entity)
    {
        _entity.Add(entity);
    }

    public virtual List<TEntity> GetAll()
    {
        return _entity.ToList();
    }

    public virtual TEntity Get(TKey key)
    {
        return _entity.Find(key);
    }

    public void Remove(TEntity entity)
    {
        _entity.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _entity.Update(entity);
    }
}
