using SalesWeb.Domain.Repositories;

namespace SalesWeb.Infrastructure.Persistence.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly SalesWebDbContext _dbContext;
    public UnitOfWork(SalesWebDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }


}
