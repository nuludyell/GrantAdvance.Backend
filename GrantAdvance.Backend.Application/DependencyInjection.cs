using AutoMapper;
using GrantAdvance.Backend.Application.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrantAdvance.Backend.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        AddAutoMapper(services, configuration);

        return services;
    }

    private static void AddAutoMapper(
        IServiceCollection services,
        IConfiguration configuration)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });

        services.AddSingleton(mapperConfig.CreateMapper());
    }
}