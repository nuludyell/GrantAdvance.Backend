namespace GrantAdvance.Backend.Domain.Abstractions;

public interface IBaseRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    Task AddAsync(TEntity entity);
}