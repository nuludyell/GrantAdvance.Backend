using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrantAdvance.Backend.WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly ISender _sender;

    public ApiControllerBase(ISender sender)
    {
        _sender = sender;
    }
}