using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Contracts;
using ToDo.Application.Services;

namespace ToDo.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection service)
    {
        service.AddScoped<IToDoItemService, ToDoItemService>();
        service.AddScoped<IUserService, UserService>();

        return service;
    }
}