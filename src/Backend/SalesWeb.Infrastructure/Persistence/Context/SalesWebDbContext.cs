using Microsoft.EntityFrameworkCore;
using SalesWeb.Domain.Entities.Department;
using SalesWeb.Domain.Entities.Seller;
namespace SalesWeb.Infrastructure.Persistence.Context;

public class SalesWebDbContext : DbContext
{
    public SalesWebDbContext(DbContextOptions<SalesWebDbContext> options)
       : base(options)
    {
    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Seller> Sellers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesWebDbContext).Assembly);
    }

}
