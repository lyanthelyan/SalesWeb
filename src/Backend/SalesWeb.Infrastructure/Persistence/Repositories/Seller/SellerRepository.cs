using Microsoft.EntityFrameworkCore;
using SalesWeb.Domain.Entities.Seller;
using SalesWeb.Domain.Repositories;
using SalesWeb.Infrastructure.Persistence.Context;

namespace SalesWeb.Infrastructure.Persistence.Repositories;

public class SellerRepository : ISellerRepository
{
    private readonly SalesWebDbContext _dbContext;
    public SellerRepository(SalesWebDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Seller seller)
    {
        await _dbContext.Sellers.AddAsync(seller);
    }
    public async Task<List<Seller>> GetAll()
    {
        return await _dbContext.Sellers
            .Include(seller => seller.Department)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Seller?> GetById(Guid id)
    {
        return await _dbContext.Sellers
            .FirstOrDefaultAsync(seller => seller.Id == id);
    }
    public async Task<bool> ExistActiveSellerEmail(string email)
    {
        return await _dbContext.Sellers
            .AnyAsync(seller =>
            seller.Active &&
            seller.Email.Equals(email));
    }
    public async Task Delete(Guid id)
    {
        var seller = await _dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Id == id);

        if (seller == null)
            return;
        
        _dbContext.Sellers.Remove(seller);
    }

}
