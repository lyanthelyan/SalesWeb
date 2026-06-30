using SalesWeb.Domain.Entities.Department;

namespace SalesWeb.Domain.Repositories;

public interface IDepartmentRepository
{
    Task<bool> ExistActiveDepartmentName(string name);
    Task<bool> ExistActiveDepartmentNameExceptId(string name, Guid id);
    Task Add(Department department);
    Task<Department?> GetById(Guid id);
    Task<Department?> GetDetailsById(Guid id);
    Task <List<Department>> GetAll();
    Task Delete(Guid id);
}
