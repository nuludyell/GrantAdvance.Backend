using AutoMapper;
using GrantAdvance.Backend.Application.Abstractions.Messaging.Query;
using GrantAdvance.Backend.Domain.Products;

namespace GrantAdvance.Backend.Application.Products.GetProducts;

internal sealed class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository
            .GetProductsAsync();

        return _mapper.Map<IReadOnlyList<ProductResponse>>(products);
    }
}