using Microsoft.EntityFrameworkCore;
using SalesWeb.Domain.Entities.Department;
namespace SalesWeb.Infrastructure.Persistence.Context;

public class SalesWebDbContext : DbContext
{
    public SalesWebDbContext(DbContextOptions<SalesWebDbContext> options)
       : base(options)
    {
    }
    public DbSet<Department> Departments { get; set; }

}
