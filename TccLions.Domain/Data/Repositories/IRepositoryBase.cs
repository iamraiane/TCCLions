using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Repositories;

public interface IRepositoryBase<TEntity, TKey> where TEntity : Entity<TKey>
{
    TEntity Get(TKey key);
    void Create(TEntity entity);
    Task<bool> SaveChangesAsync();
    void Remove(TEntity entity);
    void Update(TEntity entity);
}
