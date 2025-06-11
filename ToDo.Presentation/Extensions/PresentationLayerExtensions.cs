using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ToDo.Presentation.Contracts.Mappers;
using ToDo.Presentation.Mappers;

namespace ToDo.Presentation.Extensions;

public static class PresentationLayerExtensions
{
    public static IServiceCollection ConfigurePresentationLayer(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddControllers();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API ToDo.Backend", Version = "v1" });
        });

        ConfigureMappers(services);
        
        return services;
    }

    private static IServiceCollection ConfigureMappers(IServiceCollection service)
    {
        service.AddScoped<IToDoItemMapper, ToDoItemMapper>();
        service.AddScoped<IUserMapper, UserMapper>();

        return service;
    }
}