using SalesWeb.Domain.Entities.Department;

namespace SalesWeb.Domain.Repositories;

public interface IDepartmentRepository
{
    void Add(Department department);
    Department? GetById(Guid id);
    List<Department> GetAll();
}
