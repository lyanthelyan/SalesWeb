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

    public Department? GetById(Guid id)
    {
        return _dbContext.Departments
            .AsNoTracking()
            .FirstOrDefault(d => d.Id == id);
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
}
