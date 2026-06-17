namespace SalesWeb.Domain.Entities.Seller;

public class Seller
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateTime BirthDate { get; private set; }
    public decimal BaseSalary { get; private set; }

    public Guid DepartmentId { get; private set; }
    public Department.Department Department { get; private set; } = default!;

    public Seller(string name, string email, DateTime birthDate, decimal baseSalary, Guid departmentId)
    { 
        SellerValidate.ValidateSeller(name, email, birthDate, baseSalary, departmentId);
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        DepartmentId = departmentId;
        
    }
}
