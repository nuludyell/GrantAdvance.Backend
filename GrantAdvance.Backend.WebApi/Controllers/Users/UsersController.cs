using GrantAdvance.Backend.Application.Users.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrantAdvance.Backend.WebApi.Controllers.Users;

public sealed class UsersController : ApiControllerBase
{
    public UsersController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// POST api/users/login
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Access Token</returns>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LogInUserRequest request)
    {
        var command = new LogInUserCommand(request.Email, request.Password);

        var accessToken = await _sender.Send(command);

        return Ok(accessToken);
    }
}