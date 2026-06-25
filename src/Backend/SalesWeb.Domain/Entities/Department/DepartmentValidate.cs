namespace SalesWeb.Domain.Entities.Department;

public static class DepartmentValidate
{
    public static void ValidateDepartment(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Department name cannot be empty.");
    }
}