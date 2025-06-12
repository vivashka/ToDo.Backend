using ToDo.Application.Extensions;
using ToDo.Infrastructure.Migrator.Extensions;
using ToDo.Infrastructure.Migrator.Migrations.Database;
using ToDo.Infrastructure.Postgres.Extensions;
using ToDo.Presentation.Extensions;

namespace ToDo.Host;

public class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                true)
            .Build();
        
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.ConfigurePresentationLayer();
        builder.Services.ConfigureApplication();
        builder.Services.ConfigureInfrastructurePostgres();

        var app = builder.Build();
        app.MigrateDatabase();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        
        app.UseAuthorization();
        app.MapControllers(); 
        
        await app.RunAsync();
    }
}