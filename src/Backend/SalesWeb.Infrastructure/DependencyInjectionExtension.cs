using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesWeb.Domain.Entities.Department;
using SalesWeb.Domain.Repositories;
using SalesWeb.Infrastructure.Persistence.Context;
using SalesWeb.Infrastructure.Persistence.Repositories;

namespace SalesWeb.Infrastructure;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SalesWebDbContext>(options =>
        {
            options.UseMySql(
                configuration.GetConnectionString("Default"),
                ServerVersion.AutoDetect(
                    configuration.GetConnectionString("Default"))
            );
        });

        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
