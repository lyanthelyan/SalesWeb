namespace SalesWeb.Domain.Entities.Department;

public class Department
{
    private string v;

    public Department(string v)
    {
        this.v = v;
    }

    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Name { get; private set; }
}
