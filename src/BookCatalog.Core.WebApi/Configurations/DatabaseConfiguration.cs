using BookCatalog.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Core.WebApi.Configurations;

public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<BookCatalogContext>(
            options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnect"))
        );

        return services;
    }
}