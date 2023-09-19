using GrantAdvance.Backend.Application.Abstractions.Authentication;
using GrantAdvance.Backend.Application.Abstractions.Messaging.Command;

namespace GrantAdvance.Backend.Application.Users.LoginUser;

internal sealed class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, AccessTokenResponse>
{
    private readonly IAuthenticationService _authenticationService;

    public LogInUserCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<AccessTokenResponse> Handle(
        LogInUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _authenticationService.LoginAsync(request.Email, request.Password);

        return new AccessTokenResponse(result);
    }
}