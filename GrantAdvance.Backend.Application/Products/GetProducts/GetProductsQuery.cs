using GrantAdvance.Backend.Application.Abstractions.Messaging.Query;

namespace GrantAdvance.Backend.Application.Products.GetProducts;

public sealed record GetProductsQuery() : IQuery<IReadOnlyList<ProductResponse>>;