using GrantAdvance.Backend.Application.Products.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrantAdvance.Backend.WebApi.Controllers.Products;

public sealed class ProductsController : ApiControllerBase
{
    public ProductsController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// GET api/products
    /// </summary>
    /// <returns>List of products</returns>
    [Authorize]
    [HttpGet()]
    public async Task<IActionResult> GetProductsAsync()
    {
        var query = new GetProductsQuery();

        var result = await _sender.Send(query);

        return Ok(result);
    }
}