using GrantAdvance.Backend.Application.Abstractions.Messaging.Command;

namespace GrantAdvance.Backend.Application.Users.LoginUser;

public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<AccessTokenResponse>;