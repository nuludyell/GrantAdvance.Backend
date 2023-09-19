using GrantAdvance.Backend.Domain.Abstractions;
using GrantAdvance.Backend.Domain.Products.ValueObjects;

namespace GrantAdvance.Backend.Domain.Products;

public interface IProductRepository : IBaseRepository<Product, Id>
{
    Task<IReadOnlyList<Product>> GetProductsAsync();
}