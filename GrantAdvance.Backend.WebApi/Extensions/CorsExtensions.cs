using GrantAdvance.Backend.WebApi.Cors;

namespace GrantAdvance.Backend.WebApi.Extensions;

public static class CorsExtensions
{
    public static void AddCorsAlllowedOrigins(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var corsOptions = new CorsOptions();
        configuration.GetSection("CORS").Bind(corsOptions);

        if (corsOptions.AllowedOrigins != null && corsOptions.AllowedOrigins.Any())
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsOptions.PolicyName,
                    builder => builder
                        .WithOrigins(corsOptions.AllowedOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithExposedHeaders("content-disposition")
                        .SetPreflightMaxAge(TimeSpan.FromSeconds(2520)));
            });
        }
    }
}