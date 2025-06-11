using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Contracts.External;
using ToDo.Infrastructure.Migrator.Extensions;
using ToDo.Infrastructure.Postgres.Contracts;
using ToDo.Infrastructure.Postgres.Repository;
using ToDo.Infrastructure.Postgres.Service;

namespace ToDo.Infrastructure.Postgres.Extensions;

public static class PostgresExtension
{
    private const string DbConnectionString = "POSTGRES_CONNECTION_STRING";
    public static IServiceCollection ConfigureInfrastructurePostgres(this IServiceCollection services)
    {
        string connectionStrings = GetConnectionString();
        
        services.AddMigration(connectionStrings);
        
        services.AddScoped<IToDoItemsRepository, ToDoItemsRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IPostgresToDoProvider, ToDoItemsProvider>();
        services.AddScoped<IPostgresUserProvider, UserProvider>();
        
        return services;
    }
    
    private static string GetConnectionString()
    {
        string? connectionString = Environment.GetEnvironmentVariable(DbConnectionString);

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                $"Отсутствует переменная окружения {DbConnectionString}. Заполните ее и перезапустите приложение");
        }

        return connectionString;
    }
}