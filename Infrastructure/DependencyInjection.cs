

using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
             this IServiceCollection services,
             IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(
           configuration.GetConnectionString("DefaultConnection"),
           b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
       );

            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();

        }
        );


        return services;
    }

}
