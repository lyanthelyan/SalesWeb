namespace SalesWeb.Domain.Entities.Department;

public class Department
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public bool Active { get; private set; } = true;
    public string Name { get; private set; } = string.Empty;

    public Department(string name)
    {
        DepartmentValidate.ValidateDepartment(name);
        Name = name;
    }
}
