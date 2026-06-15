using SalesWeb.Domain.Entities.Department;
using SalesWeb.Domain.Repositories;
using SalesWeb.Infrastructure.Persistence.Context;

namespace SalesWeb.Infrastructure.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly SalesWebDbContext _context;
    public DepartmentRepository(SalesWebDbContext context)
    {
        _context = context;
    }

    public void Add(Department department)
    {
        _context.Departments.Add(department);
        _context.SaveChanges();
    }

    public Department? GetById(Guid id)
    {
        return _context.Departments
            .FirstOrDefault(d => d.Id == id);
    }
    public List<Department> GetAll()
    {
        return _context.Departments.ToList();
    }
}
