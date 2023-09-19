namespace GrantAdvance.Backend.WebApi.Cors;

internal sealed class CorsOptions
{
    public string PolicyName { get; set; }
    public string[] AllowedOrigins { get; set; }
}