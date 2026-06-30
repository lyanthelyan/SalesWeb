public class RequestUpdateSellerJson
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public decimal BaseSalary { get; set; }
    public Guid DepartmentId { get; set; }
}