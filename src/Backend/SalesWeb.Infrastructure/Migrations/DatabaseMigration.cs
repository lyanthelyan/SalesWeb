
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWeb.Infrastructure.Persistence.Context;

namespace SalesWeb.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static async Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider
            .GetRequiredService<SalesWebDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
