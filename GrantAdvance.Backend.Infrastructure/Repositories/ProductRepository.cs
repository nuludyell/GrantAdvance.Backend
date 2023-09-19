using GrantAdvance.Backend.Domain.Products;
using GrantAdvance.Backend.Domain.Products.ValueObjects;
using GrantAdvance.Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GrantAdvance.Backend.Infrastructure.Repositories;

internal sealed class ProductRepository : BaseRepository<Product, Id>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }
}