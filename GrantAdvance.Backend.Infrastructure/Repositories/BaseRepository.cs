using GrantAdvance.Backend.Domain.Abstractions;
using GrantAdvance.Backend.Infrastructure.Data;

namespace GrantAdvance.Backend.Infrastructure.Repositories;

internal abstract class BaseRepository<TEntity, TEntityId> : IBaseRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbContext
            .Set<TEntity>()
            .AddAsync(entity);
    }
}