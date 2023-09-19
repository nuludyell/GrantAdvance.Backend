namespace GrantAdvance.Backend.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    Task<string> LoginAsync(
        string username,
        string password);
}