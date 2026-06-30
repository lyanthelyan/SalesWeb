using Microsoft.EntityFrameworkCore;
using SalesWeb.Domain.Entities.Department;
using SalesWeb.Domain.Repositories;
using SalesWeb.Infrastructure.Persistence.Context;

namespace SalesWeb.Infrastructure.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly SalesWebDbContext _dbContext;
    public DepartmentRepository(SalesWebDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Department department)
    {
        await _dbContext.Departments.AddAsync(department);
        
    }

    public async Task<Department?> GetById(Guid id)
    {
        return await _dbContext.Departments
            .AsNoTracking()
            .FirstOrDefaultAsync(department => department.Id == id);
    }

    public async Task<Department?> GetDetailsById(Guid id)
    {
        return await _dbContext.Departments
            .AsNoTracking()
            .Include(department => department.Sellers)
            .FirstOrDefaultAsync(department => department.Id == id);
    }
    public async Task <List<Department>> GetAll()
    {
        return await _dbContext.Departments
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<bool> ExistActiveDepartmentName(string name) 
    {
        return await _dbContext.Departments.AnyAsync(department =>
        department.Active &&
        department.Name.Equals(name));
    }
    public async Task<bool> ExistActiveDepartmentNameExceptId(string name, Guid id)
    {
        return await _dbContext.Departments.AnyAsync(department =>
        department.Active &&
        department.Id != id &&
        department.Name.Equals(name));
    }
    public async Task Delete(Guid id)
    {
        var department = await _dbContext.Departments.FirstOrDefaultAsync(department => department.Id == id);
        if (department is null)
            return;
        _dbContext.Departments.Remove(department);
    }
}
